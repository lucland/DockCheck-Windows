using DockCheckWindows.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using DockCheckWindows.Repositories;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace DockCheckWindows.UserControls
{
    public partial class UC_Dashboard : UserControl
    {
        private readonly UserRepository _userRepository;
        private readonly LiteDbService _dbService;

        public UC_Dashboard()
        {
            InitializeComponent();
            _userRepository = new UserRepository(new ApiService());
            _dbService = LiteDbService.Instance;
            PopulateCharts();
        }

        private async void PopulateCharts()
        {
            // Try to fetch data from API
            var users = await FetchDataFromApi();
            if (users == null)
            {
                // If API fails, fetch data from LiteDB
                users = _dbService.GetAll<User>("User");
            }

            // Process and display data
            ProcessAndDisplayData(users);
        }

        private void ProcessAndDisplayData(List<User> users)
        {
            int[] hourlyCountsToday = new int[24];
            Dictionary<DateTime, int> dailyCountsAll = new Dictionary<DateTime, int>();
            Dictionary<string, int> companyCounts = new Dictionary<string, int>();
            DateTime specificDate = DateTime.ParseExact("09/25/2023", "MM/dd/yyyy", CultureInfo.InvariantCulture);

            foreach (var user in users)
            {
                // Process StartJob and EndJob
                if (user.StartJob != DateTime.MinValue && user.EndJob != DateTime.MinValue)
                {
                    for (DateTime time = user.StartJob; time < user.EndJob; time = time.AddHours(1))
                    {
                        int hour = time.Hour;

                        if (time.Date == specificDate)
                        {
                            hourlyCountsToday[hour]++;
                        }

                        if (!dailyCountsAll.ContainsKey(time.Date))
                        {
                            dailyCountsAll[time.Date] = 0;
                        }
                        dailyCountsAll[time.Date]++;
                    }
                }

                // Process Company
                if (!string.IsNullOrEmpty(user.Company))
                {
                    if (!companyCounts.ContainsKey(user.Company))
                    {
                        companyCounts[user.Company] = 0;
                    }
                    companyCounts[user.Company]++;
                }
            }

            // Populate the charts
            PopulateSingleChart(chartOnBoardedToday, hourlyCountsToday, "Hora do dia", "");
            PopulateDailyChart(chartOnBoardedAll, dailyCountsAll, "Data", "");
            PopulatePieChart(chartPieEmpresas, companyCounts);
        }

        private async Task<List<User>> FetchDataFromApi()
        {
            try
            {
                string jsonResponse = await _userRepository.GetAllUsersAsync();
                var users = JsonConvert.DeserializeObject<List<User>>(jsonResponse);

                // Sync with LiteDB
                SyncWithLiteDb(users);

                return users;
            }
            catch
            {
                // Log error or handle exception
                return null;
            }
        }

        private void SyncWithLiteDb(List<User> users)
        {
            foreach (var user in users)
            {
                if (!_dbService.Exists<User>(user.Identificacao))
                {
                    _dbService.Insert(user, "User");
                }
            }
        }

        private void PopulateDailyChart(Chart chart, Dictionary<DateTime, int> dailyCounts, string xAxisTitle, string yAxisTitle)
        {
            foreach (var entry in dailyCounts)
            {
                chart.Series["A bordo"].Points.AddXY(entry.Key, entry.Value);
            }

            // Customize the chart appearance (optional)
            chart.ChartAreas[0].AxisX.Title = xAxisTitle;
            chart.ChartAreas[0].AxisY.Title = yAxisTitle;
            chart.ChartAreas[0].AxisX.TitleFont = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chart.ChartAreas[0].AxisY.TitleFont = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chart.Series["A bordo"].ChartType = SeriesChartType.Column;
        }


        private void PopulateSingleChart(Chart chart, int[] hourlyCounts, string xAxisTitle, string yAxisTitle)
        {
            for (int i = 1; i < 24; i++)
            {
                chart.Series["A bordo"].Points.AddXY(i, hourlyCounts[i]);
            }

            // Customize the chart appearance (optional)
            chart.ChartAreas[0].AxisX.Title = xAxisTitle;
            chart.ChartAreas[0].AxisY.Title = yAxisTitle;
            chart.ChartAreas[0].AxisX.TitleFont = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chart.ChartAreas[0].AxisY.TitleFont = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chart.Series["A bordo"].ChartType = SeriesChartType.FastLine;
        }

        private void PopulatePieChart(Chart chart, Dictionary<string, int> companyCounts)
        {
            foreach (var entry in companyCounts)
            {
                chart.Series["Empresas"].Points.AddXY(entry.Key, entry.Value);
            }

            //show legend text just when mouse is over the chart portion
            chart.Series["Empresas"].ToolTip = "#VALX (#PERCENT{P0})";

            //just show legend text of the 6 biggest companies with percentages
            chart.Series["Empresas"]["PieLabelStyle"] = "Outside";
            chart.Series["Empresas"]["PieLineColor"] = "Black";
            chart.Series["Empresas"]["PieLabelStyle"] = "Disabled";
            chart.Series["Empresas"]["PieStartAngle"] = "270";

            
            // Customize the chart appearance (optional)
            chart.Series["Empresas"].ChartType = SeriesChartType.Doughnut;
        }

    }
}
