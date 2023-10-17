using System;
using System.Drawing;
using System.Windows.Forms;

namespace DockCheckWindows.UserControls
{
    public partial class UC_Cadastrar : UserControl
    {
        public UC_Cadastrar()
        {
            InitializeComponent();

            textBoxNome.TextChanged += new EventHandler(this.textBoxNome_TextChanged);
            textBoxFuncao.TextChanged += new EventHandler(this.textBoxFuncao_TextChanged);
            textBoxEmpresa.TextChanged += new EventHandler(this.textBoxEmpresa_TextChanged);
            maskedTextBoxIdentidade.TextChanged += new EventHandler(this.maskedTextBoxIdentidade_TextChanged);
            maskedTextBoxCpf.TextChanged += new EventHandler(this.maskedTextBoxCpf_TextChanged);
            maskedTextBoxAso.TextChanged += new EventHandler(this.maskedTextBoxAso_TextChanged);
            maskedTextBoxNr34.TextChanged += new EventHandler(this.maskedTextBoxNr34_TextChanged);
            dateTimePickerCheckin.ValueChanged += new EventHandler(this.dateTimePickerCheckin_ValueChanged);
            dateTimePickerCheckout.ValueChanged += new EventHandler(this.dateTimePickerCheckout_ValueChanged);

            dateTimePickerCheckin.Value = DateTime.Today;
            dateTimePickerCheckout.Value = DateTime.Today;

            buttonCadastrar.Enabled = false;
            buttonRegistrar.Enabled = false;
        }

        private void ValidateFields()
        {
            DateTime asoDate, nr34Date;
            bool isAsoDateValid = DateTime.TryParseExact(maskedTextBoxAso.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out asoDate) && asoDate > DateTime.Today;
            bool isNr34DateValid = DateTime.TryParseExact(maskedTextBoxNr34.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out nr34Date) && nr34Date > DateTime.Today;

            bool areFieldsFilled =
                !string.IsNullOrEmpty(textBoxNome.Text) &&
                !string.IsNullOrEmpty(textBoxFuncao.Text) &&
                maskedTextBoxIdentidade.Text.Length == 9 &&
                !string.IsNullOrEmpty(textBoxEmpresa.Text) &&
                maskedTextBoxCpf.Text.Length == 11 &&
                isAsoDateValid &&
                isNr34DateValid &&
                dateTimePickerCheckin.Value.Date >= DateTime.Today &&
        dateTimePickerCheckout.Value.Date >= DateTime.Today &&
            dateTimePickerCheckin.Value.Date <= dateTimePickerCheckout.Value.Date;


            // Console.WriteLine(maskedTextBoxIdentidade.Text.Length.ToString());
            // Console.WriteLine(maskedTextBoxCpf.Text.Length.ToString());

            buttonCadastrar.Enabled = areFieldsFilled;
            buttonRegistrar.Enabled = areFieldsFilled;
        }


        private void buttonCadastrar_Click(object sender, EventArgs e)
        {
           
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

        private void textBoxNome_TextChanged(object sender, EventArgs e)
        {
            ValidateFields();
        }

        private void textBoxFuncao_TextChanged(object sender, EventArgs e)
        {
            ValidateFields();
        }

        private void textBoxEmpresa_TextChanged(object sender, EventArgs e)
        {
            ValidateFields();
        }

        private void maskedTextBoxIdentidade_TextChanged(object sender, EventArgs e)
        {
            ValidateFields();
        }

        private void maskedTextBoxCpf_TextChanged(object sender, EventArgs e)
        {
            ValidateFields();
        }

        private void maskedTextBoxAso_TextChanged(object sender, EventArgs e)
        {
            ValidateFields();
        }

        private void maskedTextBoxNr34_TextChanged(object sender, EventArgs e)
        {
            ValidateFields();
        }

        private void dateTimePickerCheckin_ValueChanged(object sender, EventArgs e)
        {
            ValidateFields();
        }
        
        private void dateTimePickerCheckout_ValueChanged(object sender, EventArgs e)
        {
            ValidateFields();
        }

        private void labelNumero_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxEmbarcacao_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void uploadButton_Click(object sender, EventArgs e)
        {
            //choose picture file and assign it to pictureBoxFoto
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            openFileDialog.FilterIndex = 0;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBoxFoto.Image = new Bitmap(openFileDialog.FileName);
            }
        }

        private void buttonRegistrar_Click(object sender, EventArgs e)
        {
            
        }
    }
}
