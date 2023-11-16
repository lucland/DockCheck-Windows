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
using System.IO;

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
            Dictionary<DateTime, int> dailyRfidCount = new Dictionary<DateTime, int>();
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

                // Process RFID
                if (!string.IsNullOrEmpty(user.RFID))
                {
                    if (!dailyRfidCount.ContainsKey(user.CreatedAt.Date))
                    {
                        dailyRfidCount[user.CreatedAt.Date] = 0;
                    }
                    dailyRfidCount[user.CreatedAt.Date]++;
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
            PopulateDailyChart(chartOnBoardedAll, dailyCountsAll, "Data", "");
            PopulatePieChart(chartPieEmpresas, companyCounts); 
            PopulateRfidChart(chartRfid, dailyRfidCount, "Data", "");
            PopulateCompanyRangeChart(chartCompanyRange, users);
            PopulateValidadesChart(chartValidades, users);
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

        private void SyncWithLiteDb(List<User> usersFromApi)
        {
            foreach (var user in usersFromApi)
            {
                // Check if the user already exists in the LiteDB
                bool exists = _dbService.Exists<User>(user.Identificacao);

                if (exists)
                {
                    // Update the existing user
                    _dbService.Update<User>(user);
                }
                else
                {
                    // Insert the new user
                    _dbService.Insert<User>(user, "User");
                }
            }
        }


        private void PopulateDailyChart(Chart chart, Dictionary<DateTime, int> dailyCounts, string xAxisTitle, string yAxisTitle)
        {
            // Clear existing points in the series
            chart.Series["A bordo"].Points.Clear();

            DateTime startDate = DateTime.Now.AddDays(-30);
            DateTime endDate = DateTime.Now;

            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
            {
                int count = dailyCounts.ContainsKey(date.Date) ? dailyCounts[date.Date] : 0;
                chart.Series["A bordo"].Points.AddXY(date.Date, count);
            }

            // Customize the chart appearance
            chart.ChartAreas[0].AxisX.Title = xAxisTitle;
            chart.ChartAreas[0].AxisY.Title = yAxisTitle;
            chart.ChartAreas[0].AxisX.TitleFont = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chart.ChartAreas[0].AxisY.TitleFont = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chart.Series["A bordo"].ChartType = SeriesChartType.Column;

            //hover over the chart to see the exact value
            chart.Series["A bordo"].ToolTip = "#VALY";

            // Set AxisX LabelStyle to show labels in a readable format
            chart.ChartAreas[0].AxisX.LabelStyle.Format = "MM/dd";
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

        private void PopulateRfidChart(Chart chart, Dictionary<DateTime, int> dailyCounts, string xAxisTitle, string yAxisTitle)
        {
            foreach (var entry in dailyCounts)
            {
                chart.Series["RFID's"].Points.AddXY(entry.Key, entry.Value);
            }

            // Customize the chart appearance (optional)
            chart.ChartAreas[0].AxisX.Title = xAxisTitle;
            chart.ChartAreas[0].AxisY.Title = yAxisTitle;
            chart.ChartAreas[0].AxisX.TitleFont = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chart.ChartAreas[0].AxisY.TitleFont = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chart.Series["RFID's"].ChartType = SeriesChartType.Column;
        }

        //populate chartValidades with 3 areas series, blocked users, no blocked users and total users per day
        private void PopulateValidadesChart(Chart chart, List<User> users)
        {
            // Filtrar usuários para os últimos 5 dias
            var startDate = DateTime.Now.Date.AddDays(-4);
            var filteredUsers = users.Where(u => u.CreatedAt.Date >= startDate).ToList();

            Dictionary<DateTime, int> liberadosUsersCount = new Dictionary<DateTime, int>();
            Dictionary<DateTime, int> totalUsersCount = new Dictionary<DateTime, int>();

            foreach (var user in filteredUsers)
            {
                DateTime date = user.CreatedAt.Date;

                // Inicializa os contadores para a data se ainda não existirem
                if (!liberadosUsersCount.ContainsKey(date))
                {
                    liberadosUsersCount[date] = 0;
                    totalUsersCount[date] = 0;
                }

                // Contagem de usuários liberados
                if (user.StartJob.Date == date)
                {
                    liberadosUsersCount[date]++;
                }

                totalUsersCount[date]++;
            }

            foreach (var date in totalUsersCount.Keys)
            {
                chart.Series["Total"].Points.AddXY(date, totalUsersCount[date]);
                chart.Series["Liberados"].Points.AddXY(date, liberadosUsersCount[date]);
            }

            // Customize the chart appearance
            CustomizeChartAppearance(chart);
        }

        private void CustomizeChartAppearance(Chart chart)
        {
            // Configurações de aparência do gráfico
            chart.ChartAreas[0].AxisX.Title = "Data";
            chart.ChartAreas[0].AxisY.Title = "Usuários";
            chart.ChartAreas[0].AxisX.TitleFont = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            chart.ChartAreas[0].AxisY.TitleFont = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            chart.Series["Total"].ChartType = SeriesChartType.Area;
            chart.Series["Liberados"].ChartType = SeriesChartType.Area;
            chart.Series["Total"].BorderWidth = 3;
            chart.Series["Liberados"].BorderWidth = 3;
        }


        private void PopulateCompanyRangeChart(Chart chart, List<User> users)
        {
            // Contar trabalhadores por empresa
            var workerCountByCompany = users.GroupBy(u => u.Company)
                                            .ToDictionary(g => g.Key, g => g.Count());

            // Selecionar as 5 principais empresas
            var top5Companies = workerCountByCompany.OrderByDescending(kvp => kvp.Value)
                                                    .Take(5)
                                                    .Select(kvp => kvp.Key)
                                                    .ToList();

            // Calcular o intervalo de datas para as 5 principais empresas
            DateTime minStartDate = DateTime.MaxValue;
            DateTime maxEndDate = DateTime.MinValue;
            Dictionary<string, (DateTime Start, DateTime End)> companyJobRange = new Dictionary<string, (DateTime Start, DateTime End)>();

            foreach (var user in users.Where(u => top5Companies.Contains(u.Company)))
            {
                if (!companyJobRange.ContainsKey(user.Company))
                {
                    companyJobRange[user.Company] = (user.StartJob, user.EndJob);
                }
                else
                {
                    var currentRange = companyJobRange[user.Company];
                    DateTime start = user.StartJob < currentRange.Start ? user.StartJob : currentRange.Start;
                    DateTime end = user.EndJob > currentRange.End ? user.EndJob : currentRange.End;
                    companyJobRange[user.Company] = (start, end);
                }

                minStartDate = user.StartJob < minStartDate ? user.StartJob : minStartDate;
                maxEndDate = user.EndJob > maxEndDate ? user.EndJob : maxEndDate;
            }

            // Adicionar dados ao gráfico
            foreach (var company in companyJobRange)
            {
                int index = chart.Series["Empresas"].Points.AddXY(company.Key, company.Value.Start, company.Value.End);
                DataPoint dp = chart.Series["Empresas"].Points[index];
                dp.AxisLabel = company.Key;
                dp.LegendText = $"{company.Key}: {company.Value.Start.ToShortDateString()} - {company.Value.End.ToShortDateString()}";
            }

            // Personalizar a aparência do gráfico
            CustomizeRangeChartAppearance(chart, minStartDate, maxEndDate);
        }

        private void CustomizeRangeChartAppearance(Chart chart, DateTime minStartDate, DateTime maxEndDate)
        {
            chart.ChartAreas[0].AxisX.Interval = 1;
            chart.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
            chart.ChartAreas[0].AxisX.LabelStyle.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            chart.ChartAreas[0].AxisY.Minimum = minStartDate.ToOADate();
            chart.ChartAreas[0].AxisY.Maximum = maxEndDate.ToOADate();
            chart.ChartAreas[0].AxisY.LabelStyle.Format = "dd/MM/yyyy";
            chart.ChartAreas[0].AxisY.Title = "Datas";
            chart.Series["Empresas"].ChartType = SeriesChartType.RangeBar;
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

        private void buttonSincronizar_Click(object sender, EventArgs e)
        {
            PopulateCharts();
        }

        private void buttonBaixar_Click(object sender, EventArgs e)
        {
            //download all charts as images in a PDF file
            string fileName = "Dashboard.pdf";
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string fullPath = Path.Combine(path, fileName);
            if (File.Exists(fullPath))
            {
                   File.Delete(fullPath);
            }
            //convert the charts to Bitmap images and insert all charts in the pdf file
            using (FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 10f, 10f, 10f, 0f);
                iTextSharp.text.pdf.PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                var charts = new List<Chart> { chartPieEmpresas, chartCompanyRange, chartRfid, chartValidades};
                foreach (var chart in charts)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        //resize the chart to fit in the pdf page
                        chart.Width = 500;
                        chart.Height = 300;
                        chart.SaveImage(ms, ChartImageFormat.Png);
                        iTextSharp.text.Image chartImage = iTextSharp.text.Image.GetInstance(ms.GetBuffer());
                        chartImage.ScalePercent(75f);
                        pdfDoc.Add(chartImage);
                        MessageBox.Show("PDF criado com sucesso e salvo em: " + fullPath);
                    }
                }
                pdfDoc.Close();
            }
        }

        private void chartValidades_Click(object sender, EventArgs e)
        {

        }
    }
}
