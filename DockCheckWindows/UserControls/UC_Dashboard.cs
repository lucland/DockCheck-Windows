using LiteDB;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DockCheckWindows.UserControls
{
    public partial class UC_Dashboard : UserControl
    {
        public UC_Dashboard()
        {
            InitializeComponent();
            PopulateCharts();
        }

        private void PopulateCharts()
        {
            int[] hourlyCountsToday = new int[24];
            Dictionary<DateTime, int> dailyCountsAll = new Dictionary<DateTime, int>();
            Dictionary<string, int> companyCounts = new Dictionary<string, int>();
            DateTime specificDate = DateTime.ParseExact("09/25/2023", "MM/dd/yyyy", CultureInfo.InvariantCulture);

            // Read data from the database
            var db = DatabaseManager.Instance;
            {
                var colecao = db.GetCollection<Usuario>("usuario");
                var dados = colecao.FindAll();

                // Count the number of people onboarded each hour
                foreach (var usuario in dados)
                {
                    if (usuario.Check_in_data != null && usuario.Check_out_data != null && usuario.Check_in_hora != null && usuario.Check_out_hora != null)
                    {
                        if (usuario.Check_in_data != "*" && usuario.Check_out_data != "*" &&
                            usuario.Check_in_hora != "*" && usuario.Check_out_hora != "*" &&
                            usuario.Check_in_hora.Length < 11 && usuario.Check_out_hora.Length < 9 &&
                            usuario.Check_in_data.Length > 1 && usuario.Check_out_data.Length > 0)
                        {
                            DateTime checkIn = DateTime.ParseExact(usuario.Check_in_data + " " + usuario.Check_in_hora, "MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                            DateTime checkOut = DateTime.ParseExact(usuario.Check_out_data + " " + usuario.Check_out_hora, "MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture);

                            for (DateTime time = checkIn; time < checkOut; time = time.AddHours(1))
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
                    }
                    if (usuario.Company != null)
                    {
                        if (!companyCounts.ContainsKey(usuario.Company))
                        {
                            companyCounts[usuario.Company] = 0;
                        }
                        companyCounts[usuario.Company]++;
                    }
                }
                }

            // Populate the charts
            PopulateSingleChart(chartOnBoardedToday, hourlyCountsToday, "Hora do dia", "");
            PopulateDailyChart(chartOnBoardedAll, dailyCountsAll, "Data", "");
            PopulatePieChart(chartPieEmpresas, companyCounts);
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
