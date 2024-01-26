using DockCheckWindows.Models;
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

        private List<string> onboardedCompanies;
        private List<int> companiesCount;

        public UC_Home()
        {
            InitializeComponent();
            apiService = new ApiService();
            vesselRepository = new VesselRepository(apiService);
            userRepository = new UserRepository(apiService);
            InitializeListViewColumns();
            InitializeCompanyLists();
            CarregarDados();
        }

        private void InitializeCompanyLists()
        {
            onboardedCompanies = new List<string>();
            companiesCount = new List<int>();
        }

        private void InitializeListViewColumns()
        {
            InitializeListViewColumn(listViewABordo, new string[] { "Nome", "Numero", "Empresa", "Função" });
            InitializeListViewColumn(listViewBloqueados, new string[] { "Nome", "Número" });
            InitializeListViewColumn(listViewEmpresa, new string[] { "Contagem", "Empresa"});

            SetEqualColumnWidths(listViewEmpresa);
            SetEqualColumnWidths(listViewABordo);
            SetEqualColumnWidths(listViewBloqueados);
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
                await Task.WhenAll(PopulateListViewWithVessels(), PopulateBlockedList(), PopulateCompaniesCountList(), PopulateStatusAcao());
            }
            catch (Exception ex)
            {
                // Handle or log the exception
            }
        }

        private async Task PopulateListViewWithVessels()
        {
            listViewABordo.Items.Clear();

            var total = 0;

            var vesselIds = (Properties.Settings.Default.VesselId ?? "").Split(',');
            foreach (var id in vesselIds)
            {
                if (!string.IsNullOrEmpty(id))
                {
                    Vessel vessel = await vesselRepository.GetVesselByIdAsync(id);
                    if (vessel != null)
                    {
                        var onboarded = await vesselRepository.GetOnboardedByVesselIdAsync(id);
                        foreach (var user in onboarded)
                        {
                            if (!string.IsNullOrEmpty(user))
                            {
                                User userObj = await userRepository.GetUserByIdAsync(user);
                                if (userObj != null)
                                {
                                   if (!onboardedCompanies.Contains(userObj.Company))
                                    {
                                        onboardedCompanies.Add(userObj.Company);
                                        companiesCount.Add(1);
                                    }
                                    else
                                    {
                                        var index = onboardedCompanies.IndexOf(userObj.Company);
                                        companiesCount[index]++;
                                    }


                                    total++;
                                    listViewABordo.Items.Add(new ListViewItem(new[] {  userObj.Name, userObj.Number.ToString(), userObj.Company, userObj.Role }));
                                    await PopulateCompaniesCountList();
                                }
                            }
                        }
                    }
                }
            }

            Invoke(new Action(() =>
            {
                labelTotalABordo.Text = total.ToString();
            }));

            listViewABordo.Sorting = SortOrder.Ascending;
            listViewABordo.Sort();
        }


        private async Task PopulateBlockedList()
        {
            listViewBloqueados.Items.Clear();
            var blockedUserIds = await userRepository.GetAllBlockedUsersAsync();

            foreach (var id in blockedUserIds)
            {
                if (!string.IsNullOrEmpty(id))
                {
                    User user = await userRepository.GetUserByIdAsync(id);
                    if (user != null)
                    {
                        listViewBloqueados.Items.Add(new ListViewItem(new[] { user.Name, user.Number.ToString() }));
                    }
                }
            }

            Invoke(new Action(() =>
            {
                labelTotalBloqueados.Text = listViewBloqueados.Items.Count.ToString();
            }));
        }


        private async Task PopulateCompaniesCountList()
        {
            listViewEmpresa.Items.Clear();


            // Assuming onboardedCompanies, companiesStart, companiesCount are updated elsewhere
            for (int i = 0; i < onboardedCompanies.Count; i++)
                {
                    string companyName = onboardedCompanies[i];
                    string userCount = companiesCount[i].ToString();

                listViewEmpresa.Items.Add(new ListViewItem(new[] { userCount, companyName }));
                }


            listViewEmpresa.Sorting = SortOrder.Descending;
            listViewEmpresa.Sort();
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
                        UpdateStatusAction(ev.PortalId, ev.Timestamp);
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
    }
}
