﻿using System;
using AForge.Video;

using System.Drawing;
using System.Windows.Forms;
using System.IO.Ports;
using Newtonsoft.Json;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Collections.Generic;
using DockCheckWindows.Models;
using DockCheckWindows.Services;
using DockCheckWindows.Repositories;
using Alturos.Yolo.Extensions;
using System.Globalization;

namespace DockCheckWindows.UserControls
{
    public partial class UC_Cadastrar : UserControl
    {
        private SerialPort serialPort;
        private readonly UserRepository _userRepository;
        private readonly SupervisorRepository _supervisorRepository;
        private readonly AuthorizationRepository _authorizationRepository;
        private readonly VesselRepository _vesselRepository;

        public UC_Cadastrar(UserRepository userRepository, VesselRepository vesselRepository, AuthorizationRepository authorizationRepository)
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

            _userRepository = userRepository;
            _vesselRepository = vesselRepository;
            _authorizationRepository = authorizationRepository;
            
        }

    


        private async void ValidateFields()
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
                dateTimePickerCheckin.Value.Date <= dateTimePickerCheckout.Value.Date &&
                pictureBoxFoto.Image != null;

            //if isAdmin or isSupervisor is checked, require username and password
            if (guna2ToggleSwitch1.Checked)
            {
                areFieldsFilled = areFieldsFilled &&
                    !string.IsNullOrEmpty(usuarioTextBox.Text) &&
                    !string.IsNullOrEmpty(senhaTextBox.Text);
            }

            if (areFieldsFilled)
            {
                   if (guna2ToggleSwitch1.Checked)
                {
                    //check if username is already in use
                    bool username = await _userRepository.CheckUsernameAsync(usuarioTextBox.Text);
                    if (username == false)
                    {
                        areFieldsFilled = false;
                        MessageBox.Show("Nome de usuário já está em uso.");
                    }
                }
            }

            buttonCadastrar.Enabled = areFieldsFilled;
            buttonRegistrar.Enabled = areFieldsFilled;
        }

        private async void buttonCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                // Generate salt and hash if needed
                var salt = guna2ToggleSwitch1.Checked ? GenerateSalt() : "";
                var hash = (guna2ToggleSwitch1.Checked && senhaTextBox.Text != "") ? GenerateHash(senhaTextBox.Text, salt) : "";

                DateTime asoDate;
                bool asoDateParsed = DateTime.TryParseExact(maskedTextBoxAso.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out asoDate);

                DateTime nr34Date;
                bool nr34DateParsed = DateTime.TryParseExact(maskedTextBoxNr34.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out nr34Date);

                DateTime nr10Date;
                bool nr10DateParsed = DateTime.TryParseExact(maskedTextBoxNr10.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out nr10Date);

                DateTime nr33Date;
                bool nr33DateParsed = DateTime.TryParseExact(maskedTextBoxNr33.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out nr33Date);

                DateTime nr35Date;
                bool nr35DateParsed = DateTime.TryParseExact(maskedTextBoxNr35.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out nr35Date);


                // Create new user object
                User newUser = new User
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = textBoxNome.Text,
                        Role = textBoxFuncao.Text,
                        Company = textBoxEmpresa.Text,
                        Identidade = maskedTextBoxIdentidade.Text.Replace(" ", ""),
                        CPF = maskedTextBoxCpf.Text.Replace(" ", ""),
                        ASO = asoDateParsed ? asoDate : DateTime.MinValue,
                        NR34 = nr34DateParsed ? nr34Date : DateTime.MinValue,
                        Number = int.Parse(labelNumero.Text),
                        HasNR10 = maskedTextBoxNr10.Text != "",
                        NR10 = nr10DateParsed ? nr10Date : DateTime.MinValue,
                        HasNR33 = maskedTextBoxNr33.Text != "",
                        NR33 = nr33DateParsed ? nr33Date : DateTime.MinValue,
                        HasNR35 = maskedTextBoxNr35.Text != "",
                        NR35 = nr35DateParsed ? nr35Date : DateTime.MinValue,
                        HasASO = maskedTextBoxAso.Text != "",
                        ASODocument = escolherASOButton.Text ?? "",
                        NR34Document = escolherNR34Button.Text ?? "",
                        NR35Document = escolherNR35Button.Text ?? "",
                        NR33Document = escolherNR33Button.Text ?? "",
                        NR10Document = escolherNR10Button.Text ?? "",
                        IsAdmin = guna2ToggleSwitch1.Checked,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        IsGuardian = guardiaoToggleSwitch1.Checked,
                        Username = guna2ToggleSwitch1.Checked == true ? usuarioTextBox.Text : "",
                        Salt = guna2ToggleSwitch1.Checked == true ? salt : "",
                        Hash = guna2ToggleSwitch1.Checked == true ? hash : "",
                        StartJob = dateTimePickerCheckin.Value,
                        EndJob = dateTimePickerCheckout.Value,
                        Email = textBoxEmail.Text ?? "",
                        Picture = pictureBoxFoto.Image != null ? label3.Text : "",
                        RFID = label5.Text ?? "",
                        Project = comboBoxEmbarcacao.Text ?? "",
                        IsVisitor = visitanteToggleSwitch.Checked,
                    };

                    // Create new authorization object
                    Authorization newAuthorization = new Authorization
                {
                    Id = Guid.NewGuid(),
                    UserId = newUser.Id,
                    ExpirationDate = newUser.EndJob,
                    // VesselId will be set after retrieving it from the VesselRepository
                };
                
                var vesselId = await _vesselRepository.GetVesselIdByNameAsync(comboBoxEmbarcacao.Text);
                if (string.IsNullOrEmpty(vesselId))
                {
                    MessageBox.Show("Embarcação não encontrada.");
                    return;
                }
                
                newAuthorization.VesselId = "vessel1";

                // Add the authorization id to the  AuthorizationsId from the new user
                List<Guid> authorizationsId = new List<Guid>
                {
                    newAuthorization.Id
                };
                newUser.AuthorizationsId = authorizationsId.ToArray();

                // Save the user using UserRepository
                //if user is supervisor, save it using SupervisorRepository
                Console.WriteLine(newUser.ToJson()) ;
                if (guna2ToggleSwitch1.Checked)
                {
                    var supervisor = new Supervisor
                    {
                        Id = newUser.Id,
                        Name = newUser.Name,
                        Username = newUser.Username,
                        Salt = newUser.Salt,
                        Hash = newUser.Hash,
                        CompanyId = newUser.Company,
                        UpdatedAt = DateTime.Now
                    };

                    var supervisorCreationResult = await _supervisorRepository.CreateSupervisorAsync(supervisor);
                    if (supervisorCreationResult == null)
                    {
                        MessageBox.Show("Erro ao cadastrar supervisor.");
                        return;
                    }
                }

                if (!guna2ToggleSwitch1.Checked)
                {
                    var userCreationResult = await _userRepository.CreateUserAsync(newUser);
                    if (userCreationResult == false)
                    {
                        MessageBox.Show("Erro ao cadastrar usuário.");
                        return;
                    }

                    // Save the authorization using AuthorizationRepository
                    var authorizationCreationResult = await _authorizationRepository.CreateAuthorizationAsync(newAuthorization);
                    if (authorizationCreationResult == null)
                    {
                        MessageBox.Show("Erro ao criar autorização.");
                        return;
                    }
                }

                MessageBox.Show("Usuário cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar usuário: " + ex.Message);
            }
        }

        private string GenerateSalt()
        {
            byte[] randomBytes = new byte[128 / 8];
            using (var generator = RandomNumberGenerator.Create())
            {
                generator.GetBytes(randomBytes);
                return Convert.ToBase64String(randomBytes);
            }
        }

        private string GenerateHash(string password, string salt)
        {
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, Encoding.UTF8.GetBytes(salt), 10000))
            {
                byte[] hash = pbkdf2.GetBytes(20);
                return Convert.ToBase64String(hash);
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
            if (maskedTextBoxCpf.Text == "12086189702")
            {
                supervisorToggleSwitch.Visible = true;
                supervisorLabel.Visible = true;
            }
            else
            {
                supervisorToggleSwitch.Visible = false;
                supervisorLabel.Visible = false;
            }
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
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            openFileDialog.FilterIndex = 0;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBoxFoto.Image = new Bitmap(openFileDialog.FileName);
                excludeImageButton.Visible = true;
            }

            ValidateFields();
        }

        private void buttonRegistrar_Click(object sender, EventArgs e)
        {
            ValidateFields();
            

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

            ValidateFields();
        }

        private void excludeImageButton_Click(object sender, EventArgs e)
        {
            pictureBoxFoto.Image = null;
            excludeImageButton.Visible = false;

            ValidateFields();
        }

        public void PopulateFields(User user)
        {
            textBoxNome.Text = user.Name;
            textBoxFuncao.Text = user.Role;
            textBoxEmpresa.Text = user.Company;
            labelNumero.Text =  user.Number.ToString();
            maskedTextBoxIdentidade.Text = user.Identidade;
            maskedTextBoxCpf.Text = user.CPF;
            maskedTextBoxAso.Text = user.ASO.ToString("dd/MM/yyyy");
            maskedTextBoxNr34.Text = user.NR34.ToString("dd/MM/yyyy");
            maskedTextBoxNr35.Text = user.NR35.ToString("dd/MM/yyyy");
            maskedTextBoxNr33.Text = user.NR33.ToString("dd/MM/yyyy");
            maskedTextBoxNr10.Text = user.NR10.ToString("dd/MM/yyyy");
            dateTimePickerCheckin.Value = user.StartJob;
            dateTimePickerCheckout.Value = user.EndJob;
            textBoxEmail.Text = user.Email;
            pictureBoxFoto.Image = user.Picture != "" ? new Bitmap(user.Picture) : null;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PDF files (*.pdf) | *.pdf";
            openFileDialog.FilterIndex = 0;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (string.IsNullOrEmpty(escolherASOButton.Text))
                {
                    escolherASOButton.Text = openFileDialog.SafeFileName;
                }
                else
                {
                    escolherASOButton.Text += "\n" + openFileDialog.SafeFileName;
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

        private void escolherNR34Button_Click(object sender, EventArgs e)
        {
            //choose file and display the name of it on label4
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PDF files (*.pdf) | *.pdf";
            openFileDialog.FilterIndex = 0;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //show only the file name instead of the whole path of it
                if (string.IsNullOrEmpty(escolherNR34Button.Text))
                {
                    escolherNR34Button.Text = openFileDialog.SafeFileName;
                }
                else
                {
                    escolherNR34Button.Text += "\n" + openFileDialog.SafeFileName;
                }
            }

            ValidateFields();
        }

        private void escolherNR10Button_Click(object sender, EventArgs e)
        {
            //choose file and display the name of it on label4
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PDF files (*.pdf) | *.pdf";
            openFileDialog.FilterIndex = 0;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //show only the file name instead of the whole path of it
                if (string.IsNullOrEmpty(escolherNR10Button.Text))
                {
                    escolherNR10Button.Text = openFileDialog.SafeFileName;
                }
                else
                {
                    escolherNR10Button.Text += "\n" + openFileDialog.SafeFileName;
                }
            }

            ValidateFields();
        }

        private void escolherNR33Button_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PDF files (*.pdf) | *.pdf";
            openFileDialog.FilterIndex = 0;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (string.IsNullOrEmpty(escolherNR33Button.Text))
                {
                    escolherNR33Button.Text = openFileDialog.SafeFileName;
                }
                else
                {
                    escolherNR33Button.Text += "\n" + openFileDialog.SafeFileName;
                }
            }

            ValidateFields();
        }

        private void escolherNR35Button_Click(object sender, EventArgs e)
        {
            //choose file and display the name of it on label4
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PDF files (*.pdf) | *.pdf";
            openFileDialog.FilterIndex = 0;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //show only the file name instead of the whole path of it
                if (string.IsNullOrEmpty(escolherNR35Button.Text))
                {
                    escolherNR35Button.Text = openFileDialog.SafeFileName;
                }
                else
                {
                    escolherNR35Button.Text += "\n" + openFileDialog.SafeFileName;
                }
            }

            ValidateFields();
        }

        private void guna2ToggleSwitch1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch1.Checked)
            {
                usuarioLabel.Visible = true;
                usuarioPanel.Visible = true;
                usuarioReqLabel.Visible = true;
                usuarioTextBox.Visible = true;

                senhaLabel.Visible = true;
                senhaPanel.Visible = true;
                senhaReqLabel.Visible = true;
                senhaTextBox.Visible = true;
            }

            ValidateFields();
        }

        private void guardiaoToggleSwitch1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void supervisorToggleSwitch_CheckedChanged(object sender, EventArgs e)
        {
            ValidateFields();
        }

        private void label5_TextChanged(object sender, EventArgs e)
        {
            //if RFID is empty, disable the registrar button, otherwise enable it
            if (label5.Text == "")
            {
                buttonRegistrar.Enabled = false;
            }
            else
            {
                buttonRegistrar.Enabled = true;
            }
        }
    }
}
