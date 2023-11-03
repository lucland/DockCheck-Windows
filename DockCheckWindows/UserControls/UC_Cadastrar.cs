using System;
using AForge.Video;

using System.Drawing;
using System.Windows.Forms;
using System.IO.Ports;
using Newtonsoft.Json;
using System.IO;

namespace DockCheckWindows.UserControls
{
    public partial class UC_Cadastrar : UserControl
    {
        private SerialPort serialPort;

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

            excludeImageButton.Visible = false;

            
        }

    


        private void ValidateFields()
        {
            DateTime asoDate, nr34Date;
            bool isAsoDateValid = true;
            bool isNr34DateValid = true;

            if (!visitanteToggleSwitch.Checked)
            {
                isAsoDateValid = DateTime.TryParseExact(maskedTextBoxAso.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out asoDate) && asoDate > DateTime.Today;
                isNr34DateValid = DateTime.TryParseExact(maskedTextBoxNr34.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out nr34Date) && nr34Date > DateTime.Today;
            }

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

            buttonCadastrar.Enabled = areFieldsFilled;
            buttonRegistrar.Enabled = areFieldsFilled;
        }


        private void buttonCadastrar_Click(object sender, EventArgs e)
        {
            // Assuming all fields are validated before this point
            try
            {
                User newUser = new User
                {
                    Name = textBoxNome.Text,
                    Role = textBoxFuncao.Text,
                    Company = textBoxEmpresa.Text,
                    Identidade = maskedTextBoxIdentidade.Text.Replace(" ", ""),
                    CPF = maskedTextBoxCpf.Text.Replace(" ", ""),
                    ASO = DateTime.ParseExact(maskedTextBoxAso.Text, "dd/MM/yyyy", null),
                    NR34 = DateTime.ParseExact(maskedTextBoxNr34.Text, "dd/MM/yyyy", null),
                    ASODocument = label4.Text,
                    NR34Document = label4.Text,
                    Number = int.Parse(labelNumero.Text),

                    StartJob = dateTimePickerCheckin.Value,
                    EndJob = dateTimePickerCheckout.Value,
                    Email = textBoxEmail.Text,
                    // Add other properties as needed
                };

                // Serialize the new user object to JSON
                string json = JsonConvert.SerializeObject(newUser, Formatting.Indented);

                // Write the JSON to a file, appending a new line if the file already exists.
                string path = "path_to_your_output_directory";
                string fileName = "users.json";
                File.AppendAllText(Path.Combine(path, fileName), json + Environment.NewLine);

                MessageBox.Show("Usuário cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                // Handle exceptions
                MessageBox.Show("Erro ao cadastrar usuário: " + ex.Message);
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

        private void comboBoxEmbarcacao_SelectedIndexChanged(object sender, EventArgs e)
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
                excludeImageButton.Visible = true;
            }
        }

        private void buttonRegistrar_Click(object sender, EventArgs e)
        {

        }

        private void visitanteToggleSwitch_CheckedChanged(object sender, EventArgs e)
        {
            ValidateFields();

            if (visitanteToggleSwitch.Checked)
            {
                obrigatorioAso.Visible = false;
                obrigatorioNr34.Visible = false;
            }
            else
            {
                obrigatorioAso.Visible = true;
                obrigatorioNr34.Visible = true;
            }
        }

        private void capturaButton_Click(object sender, EventArgs e)
        {
            using (WebcamForm webcamForm = new WebcamForm())
            {
                if (webcamForm.ShowDialog() == DialogResult.OK)
                {
                    pictureBoxFoto.Image = webcamForm.CapturedImage;
                    excludeImageButton.Visible = true;
                }
            }
        }

        private void excludeImageButton_Click(object sender, EventArgs e)
        {
            //clear pictureBoxFoto
            pictureBoxFoto.Image = null;
            excludeImageButton.Visible = false;
        }

        public void PopulateFields(User user)
        {
            textBoxNome.Text = user.Name;
            textBoxFuncao.Text = user.Role;
            textBoxEmpresa.Text = user.Company;
            labelNumero.Text =  user.Number.ToString();
            maskedTextBoxIdentidade.Text = user.Identidade;
            maskedTextBoxCpf.Text = user.CPF;
            //convert DateTime of ASO into DD/MM/YYYY format
            maskedTextBoxAso.Text = user.ASO.ToString("dd/MM/yyyy");
            //convert DateTime of NR34 into DD/MM/YYYY format
            maskedTextBoxNr34.Text = user.NR34.ToString("dd/MM/yyyy");
            //convert DateTime of NR35 into DD/MM/YYYY format
            maskedTextBoxNr35.Text = user.NR35.ToString("dd/MM/yyyy");
            //convert DateTime of NR33 into DD/MM/YYYY format
            maskedTextBoxNr33.Text = user.NR33.ToString("dd/MM/yyyy");
            //convert DateTime of NR10 into DD/MM/YYYY format
            maskedTextBoxNr10.Text = user.NR10.ToString("dd/MM/yyyy");
            dateTimePickerCheckin.Value = user.StartJob;
            dateTimePickerCheckout.Value = user.EndJob;
            textBoxEmail.Text = user.Email;
        }

        private void labelNumero_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            //choose file and display the name of it on label4
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PDF files (*.pdf) | *.pdf";
            openFileDialog.FilterIndex = 0;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //show only the file name instead of the whole path of it
                if (string.IsNullOrEmpty(label4.Text))
                {
                    label4.Text = openFileDialog.SafeFileName;
                }
                else
                {
                    label4.Text += "\n" + openFileDialog.SafeFileName;
                }
            }
        }

        private void UC_Cadastrar_Load(object sender, EventArgs e)
        {
            // RFID
            serialPort = new SerialPort("COM1");
            serialPort.BaudRate = 115200;
            serialPort.Parity = Parity.None;
            serialPort.StopBits = StopBits.One;
            serialPort.DataBits = 8;
            serialPort.Handshake = Handshake.None;

            serialPort.DataReceived += new SerialDataReceivedEventHandler(SerialPort_DataReceived);

            serialPort.Open();
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // Read the data
            string rfidData = serialPort.ReadLine();

            // Update the label on the UI thread
            this.Invoke((MethodInvoker)delegate
            {
                if (rfidData != "0") {
                    label5.Text = rfidData;
                }
                
                  // Replace "myLabel" with the name of your label
            });
        }
    }
}
