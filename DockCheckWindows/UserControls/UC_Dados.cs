using DockCheckWindows.Services;
using LiteDB;
using System;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using Newtonsoft.Json;
using OfficeOpenXml;
using System.IO;

namespace DockCheckWindows.UserControls
{
    public partial class UC_Dados : UserControl
    {
        LiteDbService db;
        private UC_Cadastrar uc_Cadastrar;
        private ApiService apiService;

        public UC_Dados(UC_Cadastrar uc_CadastrarInstance, ApiService apiService)
        {
            InitializeComponent();
            this.uc_Cadastrar = uc_CadastrarInstance;
            this.apiService = apiService;
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            db = LiteDbService.Instance;
            CarregarDados();
        }

        private async void CarregarDados()
        {
            List<User> users = null;

            // Try to fetch data from API
            try
            {
                string apiResponse = await apiService.GetDataAsync("api/url/for/users"); // Replace with actual API URL
                if (!string.IsNullOrEmpty(apiResponse))
                {
                    users = JsonConvert.DeserializeObject<List<User>>(apiResponse);
                }
            }
            catch (Exception ex)
            {
                // Log or handle API exception
            }

            // If API call fails, fetch data from LiteDB
            if (users == null || !users.Any())
            {
                users = db.GetAll<User>("User").ToList();
            }

            if (users != null)
            {
                cadastrosDataGrid.DataSource = new BindingSource(users, null);
                comboBoxOrdenar.DataSource = typeof(User).GetProperties().Select(p => p.Name).ToList();

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
            if (e.RowIndex >= 0)
            {
                var user = cadastrosDataGrid.Rows[e.RowIndex].DataBoundItem as User;
                if (user != null)
                {
                    // Assuming uc_Cadastrar is an instance of UC_Cadastrar
                    uc_Cadastrar.PopulateFields(user);

                    SwitchToCadastro?.Invoke();

                    //call EdicaoUsuario passing the selected Cadastro
                    //EdicaoUsuario edicaoUsuario = new EdicaoUsuario(cadastro);
                    //show EdicaoUsuario as a dialog
                    //edicaoUsuario.ShowDialog();

                    // Code to switch to the UC_Cadastrar UserControl
                    // This depends on how you're managing UserControls in your application
                }
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

        private void UC_Dados_Load(object sender, EventArgs e)
        {
            CarregarDados();
        }
    }
}
