using DockCheckWindows.Models;
using DockCheckWindows.Repositories;
using DockCheckWindows.Services;
using Guna.Charts.Interfaces;
using Guna.Charts.WinForms;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DockCheckWindows.UserControls
{
    public partial class UC_Home : UserControl
    {
        private readonly ApiService apiService;
        private readonly VesselRepository vesselRepository;
        private readonly UserRepository userRepository;
        private readonly EmployeeRepository employeeRepository;
        private readonly SensorRepository sensorRepository;

        private List<string> onboardedCompanies;
        private List<string> onboardedEmployees;
        private List<int> companiesCount;

        private GunaChart gunaChart;
        private GunaBarDataset gunaBarDataset;

        public UC_Home()
        {
            InitializeComponent();
            apiService = new ApiService();
            vesselRepository = new VesselRepository(apiService);
            userRepository = new UserRepository(apiService);
            employeeRepository = new EmployeeRepository(apiService);
            sensorRepository = new SensorRepository(apiService);

            InitializeCompanyLists();
            CarregarDados();
        }

        private void InitializeCompanyLists()
        {
            onboardedCompanies = new List<string>();
            companiesCount = new List<int>();
        }


        private async void CarregarDados()
        {
            listaPessoas.Columns.Clear();
            listaPessoas.Columns.Add("Number", "Número");
            listaPessoas.Columns.Add("Name", "Nome");
            listaPessoas.Columns.Add("Company", "Empresa");

            //make Number column width smaller
            listaPessoas.Columns[0].Width = 140;

            listaEmpresa.Columns.Clear();
            listaEmpresa.Columns.Add("Company", "Empresa");
            listaEmpresa.Columns.Add("Count", "Quantidade");
            listaEmpresa.Columns.Add("Hour", "Horário de Entrada");



            try
            {
                List<Employee> employees = await employeeRepository.GetAllEmployeeOnboardedAsync(limit: 1000, offset: 0);
                if (employees == null || !employees.Any())
                {
                    MessageBox.Show("No employees fetched or list is null.");
                    return;
                }

                

                foreach (var employee in employees)
                {
                    listaPessoas.Rows.Add(employee.Number, employee.Name, employee.ThirdCompanyId); 

                }

                this.Invoke((MethodInvoker)delegate
                {
                    labelTotalEmbarcacao.Text = employees.Count.ToString();
                    MessageBox.Show("Label updated to: " + employees.Count.ToString());  // Debugging message
                });

                var employeesByCompany = employees.GroupBy(e => e.ThirdCompanyId).ToList();
                foreach (var company in employeesByCompany)
                {
                    onboardedCompanies.Add(company.Key);
                    companiesCount.Add(company.Count());

                    listaEmpresa.Rows.Add(company.Key, company.Count());
                    
                }

                DateTime oneDayAgo = DateTime.Now.AddHours(-24);
                List<Employee> recentEmployees = employees.Where(e => e.LastTimeFound >= oneDayAgo).ToList();

                if (recentEmployees == null || !recentEmployees.Any())
                {
                    MessageBox.Show("No recent employees found or list is null.");
                    return;
                }

                //employeeRepository.GetAllEmployeeDailiesAsync() return a list of Daily objects, populate the chartMovimentacao with the data from the Dailys where param first is a timestamp of today

                List<Daily> dailies = await employeeRepository.GetAllEmployeeDailiesAsync();
                List<Daily> dailiesToday = dailies.Where(d => d.First.Date == DateTime.Now.Date).ToList();



                this.Invoke((MethodInvoker)delegate
                {
                   UpdateChartData(dailiesToday);
                });


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message); // Show exception message
            }

        }
        
        private void UpdateChartData(List<Daily> groupedData)
        {
            // Set up GunaBarDataset
            gunaBarDataset = new GunaBarDataset();
            gunaBarDataset.Label = "Quantidade";

            // Add the datasets to the Datasets collection of GunaChart
            chartMovimentacao.Datasets.Add(gunaBarDataset);

            // Generate data and labels for the datasets
            GenerateDataAndLabels(groupedData);
        }

        private void GenerateDataAndLabels(List<Daily> groupedData)
        {
            // Sample labels for the x-axis representing hours of the day
            string[] hours = { "0h", "1h", "2h", "3h", "4h", "5h", "6h", "7h", "8h", "9h", "10h", "11h", "12h", "13h", "14h", "15h", "16h", "17h", "18h", "19h", "20h", "21h", "22h", "23h" };

            // Set the datapoints to be each hour of the day (0-23) stating with 0 at y in the x-axis and then add at y the difference between the final and first hour of each groupedData Daily List point in the y-axis
            foreach (var hour in hours)
            {
                gunaBarDataset.DataPoints.Add(new LPoint(hour.ToString(), 0));
            }

            foreach (var data in groupedData)
            {
                //add 1 to every hour between first and final hour of the day in the y-axis
                for (int i = data.First.Hour; i <= data.Final.Hour; i++)
                {
                    gunaBarDataset.DataPoints[i - 3].Y += 1;
                }
            }

            //make the style of the chart with the bars beign curved corners
            gunaBarDataset.CornerRadius = 10;
            gunaBarDataset.AutoRoundedCorners = true;

            // Update the chart with the new data
            chartMovimentacao.Update();
        }


        private void buttonSincronizar_Click(object sender, EventArgs e)
        {
            CarregarDados();
        }
    }
}
