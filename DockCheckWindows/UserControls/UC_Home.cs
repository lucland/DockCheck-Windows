using DockCheckWindows.Models;
using DockCheckWindows.Repositories;
using DockCheckWindows.Services;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DockCheckWindows.UserControls
{
    public partial class UC_Home : UserControl
    {

        public UC_Home()
        {
            InitializeComponent();
            CarregarDados();

        }

        // Other methods...

        private async void PopulateListViewWithVessels()
        {

            VesselRepository vesselRepository = new VesselRepository(apiService: new ApiService());

            // Check for null or provide a default empty string
            var vesselIds = (Properties.Settings.Default.VesselId ?? "").Split(',');

            //make list view scroll to bottom and show items organized in vertical order
            listViewABordo.View = View.Details;
            listViewABordo.Scrollable = true;
            listViewABordo.FullRowSelect = true;
            listViewABordo.Columns.Add("Embarcação", 100);
            listViewABordo.Columns.Add("A Bordo", 100);

            //make each column autosize to fit the content
            listViewABordo.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            SetEqualColumnWidths(listViewABordo, 2);

            var total = 0;

            foreach (var id in vesselIds)
            {
                if (!string.IsNullOrEmpty(id)) // Ensure id is not empty
                {
                    Vessel vessel = await vesselRepository.GetVesselByIdAsync(id);
                    if (vessel != null)
                    {
                        total = total + vessel.OnboardedCount;
                        listViewABordo.Items.Add(new ListViewItem(new[] { vessel.Name, vessel.OnboardedCount.ToString() }));
                    }
                }
            }

            labelTotalABordo.Text = "Total: " + total.ToString();
        }


        private async void PopulateBlockedList()
        {
            listViewBloqueados.Items.Clear();

            UserRepository userRepository = new UserRepository(apiService: new ApiService());

            var blockedUserIds = await userRepository.GetAllBlockedUsersAsync();

            listViewBloqueados.View = View.Details;
            listViewBloqueados.Scrollable = true;
            listViewBloqueados.FullRowSelect = true;
            listViewBloqueados.Columns.Add("Nome", 100);
            listViewBloqueados.Columns.Add("Número", 100);

            listViewBloqueados.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            SetEqualColumnWidths(listViewBloqueados, 2);

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

            labelTotalBloqueados.Text = "Total: " + listViewBloqueados.Items.Count.ToString();
        }


        private async void PopulateEventsList()
        {
            //empty list view
            listViewEventos.Items.Clear();

            VesselRepository vesselRepository = new VesselRepository(apiService: new ApiService());

            // Check for null or provide a default empty string
            var vesselIds = (Properties.Settings.Default.VesselId ?? "").Split(',');

            //make list view scroll to bottom and show items organized in vertical order
            listViewEventos.View = View.Details;
            listViewEventos.Scrollable = true;
            listViewEventos.FullRowSelect = true;
            listViewEventos.Columns.Add("Ação", 100);
            listViewEventos.Columns.Add("Portal", 100);
            listViewEventos.Columns.Add("Usuário", 100);
            listViewEventos.Columns.Add("Data", 100);

            //make each column autosize to fit the content
           // listViewEventos.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

            //show full text of every text in the list view
            listViewEventos.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            SetEqualColumnWidths(listViewEventos, 4);


            foreach (var id in vesselIds)
            {
                if (!string.IsNullOrEmpty(id)) // Ensure id is not empty
                {
                    var events = await vesselRepository.GetEventsByVesselIdAsync(id);
                    foreach (var ev in events)
                    {
                        var action = (ActionEnum)ev.Action;
                        listViewEventos.Items.Add(new ListViewItem(new[] { action.ToFriendlyString(), ev.PortalId, ev.UserId, ev.Timestamp.ToString() }));
                    }
                }
            }            
        }

        private void SetEqualColumnWidths(ListView listView, int columnCount)
        {
            if (columnCount <= 0) return;

            int width = listView.Width / columnCount;
            foreach (ColumnHeader column in listView.Columns)
            {
                column.Width = width;
            }
        }

        private void CarregarDados()
        {
            listViewABordo.Clear();
            listViewBloqueados.Clear();
            listViewEventos.Clear();
            PopulateEventsList();
            PopulateListViewWithVessels();
            PopulateBlockedList();
        }
                
        private void UC_Home_Load(object sender, EventArgs e)
        {
          
        }

        private void buttonSincronizar_Click(object sender, EventArgs e)
        {
            CarregarDados();
        }
    }
}
