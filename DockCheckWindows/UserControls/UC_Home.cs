﻿using DockCheckWindows.Models;
using DockCheckWindows.Repositories;
using DockCheckWindows.Services;
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
        private List<int> companiesCount;

        private Sensor sensorConves;
        private Sensor sensorPassadiço;
        private Sensor sensorPraça;
        private Sensor sensorPortalo;
        private Sensor sensorAcessoExterno;
        private Sensor sensorAcessoInterno;

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

    

        private void InitializeListViewColumn(ListView listView, string[] columnNames)
        {
            listView.View = View.Details;
            listView.Scrollable = true;
            listView.FullRowSelect = true;

            foreach (var columnName in columnNames)
            {
                listView.Columns.Add(columnName, -2);
            }
        }

        private async void CarregarDados()
        {
            try
            {
                await Task.WhenAll(PopulateListViewWithVessels(), PopulateStatusAcao());
            }
            catch (Exception ex)
            {
                // Handle or log the exception
            }
        }

        private async Task PopulateListViewWithVessels()
        {
            var total = 0;

            var vessel = await vesselRepository.GetVesselByIdAsync("SKANDI SALVADOR");

            if (vessel == null)
            {
                return;
            }

            labelTotalABordo.Text = vessel.OnboardedCount.ToString();

            var sensors = await sensorRepository.GetAllSensorsAsync();

            if (sensors == null || sensors.Count == 0)
            {
                return;
            }

            sensorConves = sensors.FirstOrDefault(s => s.AreaId == "Convés");

            Console.WriteLine(sensorConves.BeaconsFound.Count);

            labelTotalConves.Text = sensorConves.BeaconsFound.Count.ToString();

            sensorPassadiço = sensors.FirstOrDefault(s => s.AreaId == "Passadiço");

            labelTotalPassadiço.Text = sensorPassadiço.BeaconsFound.Count.ToString();

            sensorPraça = sensors.FirstOrDefault(s => s.AreaId == "CCM");

            labelTotalPraça.Text = sensorPraça.BeaconsFound.Count.ToString();

            sensorPortalo = sensors.FirstOrDefault(s => s.AreaId == "Portaló");

            labelTotalPortalo.Text = sensorPortalo.BeaconsFound.Count.ToString();

            sensorAcessoExterno = sensors.FirstOrDefault(s => s.AreaId == "Acesso Externo");

            labelTotalAcessoExterno.Text = sensorAcessoExterno.BeaconsFound.Count.ToString();

            sensorAcessoInterno = sensors.FirstOrDefault(s => s.AreaId == "Acesso Interno");

            labelTotalAcessoInterno.Text = sensorAcessoInterno.BeaconsFound.Count.ToString();
        

        }



        private async Task PopulateStatusAcao()
        {
            var vesselIds = (Properties.Settings.Default.VesselId ?? "").Split(',');

            foreach (var id in vesselIds)
            {
                if (!string.IsNullOrEmpty(id))
                {
                    var events = await vesselRepository.GetEventsByVesselIdAsync(id);
                    foreach (var ev in events)
                    {
                        var action = (ActionEnum)ev.Action;
                        UpdateStatusAction(ev.SensorId, ev.Timestamp);
                    }
                }
            }
        }

        private void UpdateStatusAction(string portalId, DateTime timestamp)
        {
            PortalEnum portal = (PortalEnum)Enum.Parse(typeof(PortalEnum), portalId);

            switch (portal)
            {
                case PortalEnum.P1:
                    var text1 = "Conectado";
                    statusPortalo1.FillColor = System.Drawing.Color.FromArgb(0, 192, 0);
                    statusPortalo1.BorderColor = System.Drawing.Color.FromArgb(0, 192, 0);
                    statusAcao1.Text = text1;
                    Invoke(new Action(() => { portaloData1.Text = timestamp.ToString(); }));
                    break;
                case PortalEnum.P2:
                    var text2 = "Conectado";
                    statusAcao2.Text = text2;
                    Invoke(new Action(() => { portaloData2.Text = timestamp.ToString(); }));

                    statusPortalo2.FillColor = System.Drawing.Color.FromArgb(0, 192, 0);
                    statusPortalo2.BorderColor = System.Drawing.Color.FromArgb(0, 192, 0);
                    break;
                case PortalEnum.P3:
                    var text3 = "Conectado";
                    statusAcao3.Text = text3;
                    Invoke(new Action(() => { portaloData3.Text = timestamp.ToString(); }));

                    statusPortalo3.FillColor = System.Drawing.Color.FromArgb(0, 192, 0);
                    statusPortalo3.BorderColor = System.Drawing.Color.FromArgb(0, 192, 0);
                    break;
                case PortalEnum.P4:
                    var text4 = "Conectado";
                    statusAcao4.Text = text4;
                    Invoke(new Action(() => { portaloData4.Text = timestamp.ToString(); }));

                    statusPortalo4.FillColor = System.Drawing.Color.FromArgb(0, 192, 0);
                    statusPortalo4.BorderColor = System.Drawing.Color.FromArgb(0, 192, 0);
                    break;
                default:
                    break;
            }
        }

        private void SetEqualColumnWidths(ListView listView)
        {
            int columnCount = listView.Columns.Count;
            if (columnCount <= 0) return;

            int width = listView.Width / columnCount;
            foreach (ColumnHeader column in listView.Columns)
            {
                column.Width = width;
            }
        }

        private void buttonSincronizar_Click(object sender, EventArgs e)
        {
            CarregarDados();
        }

        private void labelPortalo_Click(object sender, EventArgs e)
        {

        }
    }
}
