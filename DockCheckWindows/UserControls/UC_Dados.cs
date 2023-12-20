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

namespace DockCheckWindows.UserControls
{
    public partial class UC_Dados : UserControl
    {
        LiteDbService db;
        private UC_Cadastrar uc_Cadastrar;
        private readonly UserRepository _userRepository;
        private bool isDataLoaded = false;

        public UC_Dados(UC_Cadastrar uc_CadastrarInstance, UserRepository userRepository)
        {
            InitializeComponent();
            this.uc_Cadastrar = uc_CadastrarInstance;
            _userRepository = userRepository;
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            if (db == null)
            {
                db = LiteDbService.Instance;
            }
            if (!isDataLoaded)
            {
                CarregarDados();
            }
        }

        private async void CarregarDados()
        {
            List<User> users = null;
            bool apiFailed = false;

            try
            {
                string apiResponse = await _userRepository.GetAllUsersAsync(limit: 99, offset: 0);
                if (!string.IsNullOrEmpty(apiResponse))
                {
                    users = JsonConvert.DeserializeObject<List<User>>(apiResponse, new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        MissingMemberHandling = MissingMemberHandling.Ignore
                    });
                    isDataLoaded = true;
                    //synch data with LiteDB
                    foreach (var user in users)
                    {
                        var userInDb = db.GetByIdentificacao<User>(user.Identificacao);
                        //use exist method from LiteDbService
                        if (userInDb == null)
                        {
                            MessageBox.Show("User not in db. Inserting...");
                           db.Insert(user, "User");
                        }
                        
                    }                   
                }
            }
            catch (Exception ex)
            {
                apiFailed = true;
                // Log the exception
                Console.WriteLine("API call exception: " + ex.Message);
            }

            // If API call fails, fetch data from LiteDB
            if (apiFailed == true)
            {
                MessageBox.Show("API call failed. Fetching data from LiteDB.");
                //users = db.GetAll<User>("User").ToList();
                isDataLoaded = true;
            }

            if (users != null)
            {
                cadastrosDataGrid.DataSource = new BindingSource(users, null);
                comboBoxOrdenar.DataSource = typeof(User).GetProperties()
                    .Where(p => p.Name != "Salt" && p.Name != "Hash" && p.Name != "Username" && p.Name != "AuthorizationsId")
                    .Select(p => p.Name)
                    .ToList();
                //order the db by user.CreatedAt in descending order
                cadastrosDataGrid.DataSource = new BindingSource(users.OrderByDescending(x => x.Number).ToList(), null);

                // Hide specific columns
                cadastrosDataGrid.Columns["hasAso"].Visible = false;
                cadastrosDataGrid.Columns["hasNr34"].Visible = false;
                //hide hasNr33, hasNr10, hasNr35, rfid, salt, hash fields
                cadastrosDataGrid.Columns["hasNr33"].Visible = false;
                cadastrosDataGrid.Columns["hasNr10"].Visible = false;
                cadastrosDataGrid.Columns["hasNr35"].Visible = false;
                cadastrosDataGrid.Columns["rfid"].Visible = false;
                cadastrosDataGrid.Columns["salt"].Visible = false;
                cadastrosDataGrid.Columns["hash"].Visible = false;
                cadastrosDataGrid.Columns["isBlocked"].Visible = false;
                cadastrosDataGrid.Columns["blockReason"].Visible = false;
                cadastrosDataGrid.Columns["picture"].Visible = false;
                cadastrosDataGrid.Columns["username"].Visible = false;
            }
            else
            {
                // Handle null or empty user list (e.g., show a message or log the error)
            }
        }

        private void comboBoxOrdenar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxOrdenar.SelectedItem != null && db != null)
            {
                var colecao = db.GetAll<User>("User");
                if (colecao != null)
                {
                    var dados = colecao.ToList();
                    var propriedade = typeof(User).GetProperty(comboBoxOrdenar.SelectedItem.ToString());
                    bool isAscending = crescenteDecrescente.SelectedItem.ToString() == "CRESCENTE";

                    if (comboBoxOrdenar.SelectedItem.ToString() == "Number") // Replace "Number" with the actual field name
                    {
                        if (isAscending)
                        {
                            cadastrosDataGrid.DataSource = new BindingSource(
                                dados.OrderBy(x =>
                                {
                                    var value = propriedade.GetValue(x, null);
                                    int number;
                                    return int.TryParse(value.ToString(), out number) ? number : int.MaxValue;
                                }).ToList(), null);
                        }
                        else
                        {
                            cadastrosDataGrid.DataSource = new BindingSource(
                                dados.OrderByDescending(x =>
                                {
                                    var value = propriedade.GetValue(x, null);
                                    int number;
                                    return int.TryParse(value.ToString(), out number) ? number : int.MinValue;
                                }).ToList(), null);
                        }
                    }
                    else
                    {
                        if (isAscending)
                        {
                            cadastrosDataGrid.DataSource = new BindingSource(dados.OrderBy(x => propriedade.GetValue(x, null)).ToList(), null);
                        }
                        else
                        {
                            cadastrosDataGrid.DataSource = new BindingSource(dados.OrderByDescending(x => propriedade.GetValue(x, null)).ToList(), null);
                        }
                    }
                }
                else
                {
                    // Handle null collection (e.g., show a message or log the error)
                }
            }
            else
            {
                // Handle null database or null selectedItem (e.g., show a message or log the error)
            }
        }



        private void textBoxFiltrar_TextChanged(object sender, EventArgs e)
        {
            if (comboBoxOrdenar.SelectedItem != null)
            {
                var colecao = db.GetAll<User>("User");
                var dados = colecao.ToList();
                if (dados != null && dados.Any())
                {
                    var propriedade = typeof(User).GetProperty(comboBoxOrdenar.SelectedItem.ToString());
                    if (propriedade != null)
                    {
                        var filteredData = dados.Where(x =>
                        {
                            var value = propriedade.GetValue(x, null);
                            return value != null && value.ToString().ToLower().Contains(textBoxFiltrar.Text.ToLower());
                        }).ToList();

                        cadastrosDataGrid.DataSource = new BindingSource(filteredData, null);
                    }
                }
            }
        }

        public event Action SwitchToCadastro;

        private void cadastrosDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //select row of the clicked cell
            if (e.RowIndex > 0)
            {
                cadastrosDataGrid.Rows[e.RowIndex].Selected = true;
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

        private void crescenteDecrescente_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxOrdenar_SelectedIndexChanged(sender, e);
        }

        private void cadastrosDataGrid_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var user = cadastrosDataGrid.Rows[e.RowIndex].DataBoundItem as User;
                if (user != null)
                {
                    uc_Cadastrar.PopulateFields(user);
                    SwitchToCadastro?.Invoke();
                }
            }
        }
    }
}
