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
        public UC_Dados()
        {
            InitializeComponent();
            db = new LiteDatabase(@"C:\Users\lucas\DockCheckWindows\banco.db");
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            CarregarDados();
        }

        private void CarregarDados()
        {
            var colecao = db.GetCollection<Cadastro>("cadastro");
            var dados = colecao.FindAll().ToList();
            cadastrosDataGrid.DataSource = new BindingSource(dados, null);
            comboBoxOrdenar.DataSource = typeof(Cadastro).GetProperties().Select(p => p.Name).ToList();
        }

        private void comboBoxOrdenar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxOrdenar.SelectedItem != null)
            {
                var colecao = db.GetCollection<Cadastro>("cadastro");
                var dados = colecao.FindAll().ToList();
                var propriedade = typeof(Cadastro).GetProperty(comboBoxOrdenar.SelectedItem.ToString());
                cadastrosDataGrid.DataSource = new BindingSource(dados.OrderBy(x => propriedade.GetValue(x, null)).ToList(), null);
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
    }
}
