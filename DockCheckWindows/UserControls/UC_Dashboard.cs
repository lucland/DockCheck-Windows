using LiteDB;
using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DockCheckWindows.UserControls
{
    public partial class UC_Dashboard : UserControl
    {
        public UC_Dashboard()
        {
            InitializeComponent();
            PopulateChart();
        }

        private void PopulateChart()
        {
            
            // Initialize the array to hold the counts
            //int[] hourlyCounts = new int[24];

            // Read data from the database
           /* using (var db = new LiteDatabase(@"C:\Users\lucas\DockCheckWindows\banco.db"))
            {
                var colecao = db.GetCollection<Cadastro>("cadastro");
                var dados = colecao.FindAll();

                // Count the number of people onboarded each hour
                foreach (var cadastro in dados)
                {
                /*    for (DateTime time = cadastro.CheckIn; time < cadastro.CheckOut; time = time.AddHours(1))
                    {
                        int hour = time.Hour;
                        hourlyCounts[hour]++;
                    }
                */
              //  }
         //   }
    
             /*
            // Populate the chart
            for (int i = 0; i < 24; i++)
            {
                chartOnBoarded.Series["Series1"].Points.AddXY(i, hourlyCounts[i]);
            }

            // Customize the chart appearance (optional)
            chartOnBoarded.ChartAreas[0].AxisX.Title = "Hour of Day";
            chartOnBoarded.ChartAreas[0].AxisY.Title = "Number of People Onboarded";
            chartOnBoarded.Series["Series1"].ChartType = SeriesChartType.Column;
             */
        }

        private void chartOnBoarded_Click(object sender, EventArgs e)
        {
            // ...
        }
    }
}
