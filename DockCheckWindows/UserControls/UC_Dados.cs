using DockCheckWindows.Services;
using LiteDB;
using System;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using Newtonsoft.Json;
using OfficeOpenXml;
using System.IO;
using DockCheckWindows.Repositories;
using DockCheckWindows.Models;
using System.Web.UI.WebControls;
using System.Drawing;
using Guna.UI2.WinForms;

namespace DockCheckWindows.UserControls
{
    public partial class UC_Dados : UserControl
    {
        LiteDbService db;
        private UC_Cadastrar uc_Cadastrar;
        private readonly EmployeeRepository _employeeRepository;
        private readonly EventRepository _eventRepository;
        private bool isDataLoaded = false;
        private List<Employee> _users;
        private List<Event> _events;

        public Action SwitchToCadastro { get; set; }

        public UC_Dados(UC_Cadastrar uc_CadastrarInstance, EmployeeRepository employeeRepository, EventRepository eventRepository)
        {
            InitializeComponent();
            this.uc_Cadastrar = uc_CadastrarInstance;
            _employeeRepository = employeeRepository;
            _eventRepository = eventRepository;
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            db = LiteDbService.Instance;

            guna2WinProgressIndicator1.Visible = true;

            InitializeDropdowns();
            CarregarDados();
        }

        private void InitializeDropdowns()
        {
           crescenteDecrescente.Items.Add("CRESCENTE");
            crescenteDecrescente.Items.Add("DECRESCENTE");
            crescenteDecrescente.SelectedIndex = 0;
        }

        private void CarregarDados()
        {
            if (!isDataLoaded)
            {
                if (tableSwitchDropdown.SelectedItem.ToString() == "Usuários")
                {
                    LoadUsers();
                }
                else if (tableSwitchDropdown.SelectedItem.ToString() == "Eventos")
                {
                    LoadEvents();
                }
            }
        }

        private async void LoadUsers()
        {
            if (isDataLoaded) return;

            try
            {
                List<Employee> apiResponse = await _employeeRepository.GetAllEmployeeAsync(limit: 10000, offset: 0);
                // Upsert each user into the local database
                /* foreach (var employee in apiResponse)
                 {
                     db.UpsertUser(employee);
                 }*/

                // Reload the updated user list from the local database
                _users = apiResponse;

                    isDataLoaded = true;
                guna2WinProgressIndicator1.Visible = false;
                    // UpdateSortedAndFilteredUserDataSource();
                    cadastrosDataGrid.DataSource = new BindingSource(_users, null);
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("API call exception: " + ex.Message);
                MessageBox.Show("API call failed. Fetching data from LiteDB.");
               // _users = db.GetAll<Employee>("Employee");

                isDataLoaded = true;
                UpdateSortedAndFilteredUserDataSource();
                guna2WinProgressIndicator1.Visible = false;
            }
            UpdateComboBoxOrdenarForUsers();
        }


        private async void LoadEvents()
        {
            List<Event> events = null;
            bool apiFailed = false;

            try
            {
                string apiResponse = await _eventRepository.GetAllEventsAsync(limit: 99, offset: 0);
                if (!string.IsNullOrEmpty(apiResponse))
                {
                    events = JsonConvert.DeserializeObject<List<Event>>(apiResponse, new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        MissingMemberHandling = MissingMemberHandling.Ignore
                    });
                    isDataLoaded = true;
                    guna2WinProgressIndicator1.Visible = false;
                    cadastrosDataGrid.DataSource = new BindingSource(events, null);
                }
            }
            catch (Exception ex)
            {
                apiFailed = true;
                Console.WriteLine("API call exception: " + ex.Message);
                MessageBox.Show("API call failed.");
            }
            _events = events;
            UpdateComboBoxOrdenarForEvents();
            SortAndFilterEventData(_events);
        }

        private void UpdateComboBoxOrdenarForUsers()
        {
            comboBoxOrdenar.DataSource = null;
            comboBoxOrdenar.Items.Clear();
            comboBoxOrdenar.Items.AddRange(typeof(Employee).GetProperties()
                .Where(p => p.Name != "Salt" && p.Name != "Hash" && p.Name != "Username" && p.Name != "AuthorizationsId")
                .Select(p => p.Name).ToArray());
            if (comboBoxOrdenar.Items.Count > 0) comboBoxOrdenar.SelectedIndex = 0;
        }

        private void UpdateComboBoxOrdenarForEvents()
        {
            comboBoxOrdenar.DataSource = null;
            comboBoxOrdenar.Items.Clear();
            comboBoxOrdenar.Items.AddRange(typeof(Event).GetProperties()
                .Select(p => p.Name).ToArray());
            if (comboBoxOrdenar.Items.Count > 0) comboBoxOrdenar.SelectedIndex = 0;
        }
        private void UpdateSortedAndFilteredUserDataSource()
        {
            if (_users == null) return;
            var distinctUsers = _users.GroupBy(user => user.Id).Select(group => group.First()).ToList();
            var sortedUsers = SortUsers(distinctUsers);
            var filteredUsers = FilterUsers(sortedUsers, textBoxFiltrar.Text);
            cadastrosDataGrid.DataSource = new BindingSource(filteredUsers, null);
        }

        private List<Employee> SortUsers(List<Employee> users)
        {
            if (comboBoxOrdenar.SelectedItem == null) return users;

            var selectedProperty = typeof(Employee).GetProperty(comboBoxOrdenar.SelectedItem.ToString());
            bool isAscending = crescenteDecrescente.SelectedItem.ToString() == "CRESCENTE";

            return isAscending
                ? users.OrderBy(x => selectedProperty.GetValue(x, null)).ToList()
                : users.OrderByDescending(x => selectedProperty.GetValue(x, null)).ToList();
        }

        private List<Employee> FilterUsers(List<Employee> users, string filterText)
        {
            if (string.IsNullOrWhiteSpace(filterText)) return users;

            var selectedProperty = typeof(Employee).GetProperty(comboBoxOrdenar.SelectedItem?.ToString());
            if (selectedProperty == null) return users;

            return users.Where(user =>
            {
                var value = selectedProperty.GetValue(user, null);
                return value != null && value.ToString().ToLower().Contains(filterText.ToLower());
            }).ToList();
        }

        private void comboBoxOrdenar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tableSwitchDropdown.SelectedItem.ToString() == "Eventos")
            {
                if (_events != null) SortAndFilterEventData(_events);
            }
            else
            {
                if (_users != null) UpdateSortedAndFilteredUserDataSource();
            }
        }

        private void textBoxFiltrar_TextChanged(object sender, EventArgs e)
        {
            comboBoxOrdenar_SelectedIndexChanged(sender, e); // Reuse sorting logic
        }

        private void crescenteDecrescente_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxOrdenar_SelectedIndexChanged(sender, e); // Reuse sorting logic
        }

        private void cadastrosDataGrid_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var user = cadastrosDataGrid.Rows[e.RowIndex].DataBoundItem as Employee;
                if (user != null)
                {
                    // uc_Cadastrar.PopulateFields(user);
                    var ucEmployee = new UC_Employee(
                name: user.Name,
                identificacao: user.Number.ToString(),
                embarcacao: "Skandi Salvador",
                id: user.Id,
                empresa: user.ThirdCompanyId,
                checkin: DateTime.Now.ToString("dd/MM/yyyy"),
                role: user.Role,
                checkout: "-",
                employeeRepository: _employeeRepository
                );
                    // SwitchToCadastro?.Invoke();

                    ucEmployee.Location = new Point(400, 200);
                    ucEmployee.Size = new Size(835, 406);
                    Controls.Add(ucEmployee);
                    ucEmployee.BringToFront();
                    ucEmployee.Show();
                }
            }
        }

        private void SortAndFilterEventData(List<Event> events)
        {
            if (events == null || comboBoxOrdenar.SelectedItem == null) return;
            var sortedEvents = SortEvents(events);
            var filteredEvents = FilterEvents(sortedEvents, textBoxFiltrar.Text);
            cadastrosDataGrid.DataSource = new BindingSource(filteredEvents, null);
        }

        private List<Event> SortEvents(List<Event> events)
        {
            var selectedProperty = typeof(Event).GetProperty(comboBoxOrdenar.SelectedItem.ToString());
            bool isAscending = crescenteDecrescente.SelectedItem.ToString() == "CRESCENTE";
            return isAscending
                ? events.OrderBy(x => selectedProperty.GetValue(x, null)).ToList()
                : events.OrderByDescending(x => selectedProperty.GetValue(x, null)).ToList();
        }

        private List<Event> FilterEvents(List<Event> events, string filterText)
        {
            if (string.IsNullOrWhiteSpace(filterText) || comboBoxOrdenar.SelectedItem == null) return events;
            var selectedProperty = typeof(Event).GetProperty(comboBoxOrdenar.SelectedItem.ToString());
            return events.Where(eventItem =>
            {
                var value = selectedProperty.GetValue(eventItem, null);
                return value != null && value.ToString().ToLower().Contains(filterText.ToLower());
            }).ToList();
        }

        private void tableSwitchDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Reset the sorting and filtering
            comboBoxOrdenar.SelectedIndex = 0;
            textBoxFiltrar.Text = "";
            if (tableSwitchDropdown.SelectedItem.ToString() == "Eventos")
            {
                LoadEvents();
                UpdateComboBoxOrdenarForEvents();
            }
            else
            {
                LoadUsers();
                UpdateComboBoxOrdenarForUsers();
            }
        }

        private void buttonBaixar_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = saveFileDialog.FileName;
                ExportDataToExcel(path);
            }
        }

        private void ExportDataToExcel(string path)
        {
            using (ExcelPackage pck = new ExcelPackage())
            {
                ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Sheet1");

                // Adding Headers
                for (int i = 1; i < cadastrosDataGrid.Columns.Count + 1; i++)
                {
                    ws.Cells[1, i].Value = cadastrosDataGrid.Columns[i - 1].HeaderText;
                }

                // Adding Content
                for (int i = 0; i < cadastrosDataGrid.Rows.Count; i++)
                {
                    for (int j = 0; j < cadastrosDataGrid.Columns.Count; j++)
                    {
                        ws.Cells[i + 2, j + 1].Value = cadastrosDataGrid.Rows[i].Cells[j].Value;
                    }
                }

                pck.SaveAs(new FileInfo(path));
            }
        }

        private void cadastrosDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
