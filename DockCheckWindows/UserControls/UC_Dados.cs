using LiteDB;
using System;
using System.Linq;
using OfficeOpenXml;
using System.IO;
using System.Windows.Forms;

namespace DockCheckWindows.UserControls
{
    public partial class UC_Dados : UserControl
    {
        LiteDatabase db;
        private UC_Cadastrar uc_Cadastrar;

        public UC_Dados(UC_Cadastrar uc_CadastrarInstance)
        {
            InitializeComponent();
            this.uc_Cadastrar = uc_CadastrarInstance;
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            db = DatabaseManager.Instance;  // Initialize db using the singleton instance
            CarregarDados();
        }

        private void CarregarDados()
        {
            if (db != null)
            {
                var colecao = db.GetCollection<Cadastro>("cadastro");
                if (colecao != null)
                {
                    var dados = colecao.FindAll().ToList();
                    cadastrosDataGrid.DataSource = new BindingSource(dados, null);
                    comboBoxOrdenar.DataSource = typeof(Cadastro).GetProperties().Select(p => p.Name).ToList();
                }
                else
                {
                    // Handle null collection (e.g., show a message or log the error)
                }
            }
            else
            {
                // Handle null database (e.g., show a message or log the error)
            }
        }

        private void comboBoxOrdenar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxOrdenar.SelectedItem != null && db != null)
            {
                var colecao = db.GetCollection<Cadastro>("cadastro");
                if (colecao != null)
                {
                    var dados = colecao.FindAll().ToList();
                    var propriedade = typeof(Cadastro).GetProperty(comboBoxOrdenar.SelectedItem.ToString());
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
                var colecao = db.GetCollection<Cadastro>("cadastro");
                var dados = colecao.FindAll().ToList();
                if (dados != null && dados.Any())
                {
                    var propriedade = typeof(Cadastro).GetProperty(comboBoxOrdenar.SelectedItem.ToString());
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
                var cadastro = cadastrosDataGrid.Rows[e.RowIndex].DataBoundItem as Cadastro;
                if (cadastro != null)
                {
                    // Assuming uc_Cadastrar is an instance of UC_Cadastrar
                    uc_Cadastrar.PopulateFields(cadastro);

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

        private void cadastrosDataGrid_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
