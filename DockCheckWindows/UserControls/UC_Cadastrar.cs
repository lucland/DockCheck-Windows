using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DockCheckWindows.UserControls
{
    public partial class UC_Cadastrar : UserControl
    {
        public UC_Cadastrar()
        {
            InitializeComponent();
        }

        private void buttonCadastrar_Click(object sender, EventArgs e)
        {
            if (textBoxEmpresa.Text == "")
            {
                MessageBox.Show("Preencha o campo Empresa");
            }
            /*
            else if (textBoxNome.Text == "")
            {
                MessageBox.Show("Preencha o campo Nome");
            }
            else if (textBoxNumero.Text == "")
            {
                MessageBox.Show("Preencha o campo Número");
            }
            else if (textBoxData.Text == "")
            {
                MessageBox.Show("Preencha o campo Data");
            }
            else if (textBoxHora.Text == "")
            {
                MessageBox.Show("Preencha o campo Hora");
            }
            else if (textBoxEmbarcacao.Text == "")
            {
                MessageBox.Show("Preencha o campo Embarcação");
            }
            else if (textBoxTipo.Text == "")
            {
                MessageBox.Show("Preencha o campo Tipo");
            }
            else if (textBoxLocal.Text == "")
            {
                MessageBox.Show("Preencha o campo Local");
            }
            else if (textBoxObservacoes.Text == "")
            {
                MessageBox.Show("Preencha o campo Observações");
            }*/
            else
            {
                MessageBox.Show("Cadastro realizado com sucesso!");
            }
        }   

        private void buttonConves_Click(object sender, EventArgs e)
        {
            buttonCasario.Checked = false;
            buttonCasaDeMaquinas.Checked = false;
            buttonConves.Checked = true;
        }

        private void buttonCasaDeMaquinas_Click(object sender, EventArgs e)
        {
            buttonCasario.Checked = false;
            buttonCasaDeMaquinas.Checked = true;
            buttonConves.Checked = false;
        }

        private void buttonCasario_Click(object sender, EventArgs e)
        {
            buttonCasario.Checked = true;
            buttonCasaDeMaquinas.Checked = false;
            buttonConves.Checked = false;
        }

        private void textBoxEmpresa_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelNumero_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxEmbarcacao_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
