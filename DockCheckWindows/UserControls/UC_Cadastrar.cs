using System;
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
using System.Threading.Tasks;
using System.Linq;

namespace DockCheckWindows.UserControls
{
    public partial class UC_Cadastrar : UserControl
    {
        private SerialPort serialPort;
        private UC_Dados uc_Dados;
        private readonly UserRepository _userRepository;
        private readonly SupervisorRepository _supervisorRepository;
        private readonly AuthorizationRepository _authorizationRepository;
        private readonly VesselRepository _vesselRepository;
        private bool isEditar = false;

        public UC_Cadastrar(UserRepository userRepository, VesselRepository vesselRepository, AuthorizationRepository authorizationRepository, UC_Dados uc_DadosInstance)
        {
            InitializeComponent();

            this.uc_Dados = uc_DadosInstance;

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

            if (!isEditar)
            {
                GetLastNumberAsync();
                GetUsersRfidsByVesselAsync("vessel1");
            }

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
            if (adminToggleSwitch.Checked)
            {
                areFieldsFilled = areFieldsFilled &&
                    !string.IsNullOrEmpty(usuarioTextBox.Text) &&
                    !string.IsNullOrEmpty(senhaTextBox.Text);
            }

            buttonCadastrar.Enabled = areFieldsFilled;
            buttonRegistrar.Enabled = areFieldsFilled && textBoxRFID.Text.Length == 24;
        }

        private byte[] ImageToByteArray(PictureBox pictureBox)
        {
            using (var ms = new MemoryStream())
            {
                pictureBox.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }

        public event Action SwitchToDados;

        //function to disable/enable all buttons and textboxes
        private void DisableAll()
        {
            textBoxNome.Enabled = false;
            textBoxFuncao.Enabled = false;
            textBoxEmpresa.Enabled = false;
            maskedTextBoxIdentidade.Enabled = false;
            maskedTextBoxCpf.Enabled = false;
            maskedTextBoxAso.Enabled = false;
            maskedTextBoxNr34.Enabled = false;
            dateTimePickerCheckin.Enabled = false;
            dateTimePickerCheckout.Enabled = false;
            buttonCadastrar.Enabled = false;
            buttonRegistrar.Enabled = false;
            buttonConves.Enabled = false;
            buttonCasaDeMaquinas.Enabled = false;
            buttonCasario.Enabled = false;
            uploadButton.Enabled = false;
            capturaButton.Enabled = false;
            escolherASOButton.Enabled = false;
            escolherNR34Button.Enabled = false;
            escolherNR10Button.Enabled = false;
            escolherNR33Button.Enabled = false;
            escolherNR35Button.Enabled = false;
            visitanteToggleSwitch.Enabled = false;
            adminToggleSwitch.Enabled = false;
            guardiaoToggleSwitch.Enabled = false;
            supervisorToggleSwitch.Enabled = false;
            usuarioTextBox.Enabled = false;
            senhaTextBox.Enabled = false;
            textBoxEmail.Enabled = false;
            textBoxRFID.Enabled = false;
            pictureBoxFoto.Enabled = false;
            excludeImageButton.Enabled = false;
        }

        //function to enable all buttons and textboxes
        private void EnableAll()
        {
            textBoxNome.Enabled = true;
            textBoxFuncao.Enabled = true;
            textBoxEmpresa.Enabled = true;
            maskedTextBoxIdentidade.Enabled = true;
            maskedTextBoxCpf.Enabled = true;
            maskedTextBoxAso.Enabled = true;
            maskedTextBoxNr34.Enabled = true;
            dateTimePickerCheckin.Enabled = true;
            dateTimePickerCheckout.Enabled = true;
            buttonCadastrar.Enabled = true;
            buttonRegistrar.Enabled = true;
            buttonConves.Enabled = true;
            buttonCasaDeMaquinas.Enabled = true;
            buttonCasario.Enabled = true;
            uploadButton.Enabled = true;
            capturaButton.Enabled = true;
            escolherASOButton.Enabled = true;
            escolherNR34Button.Enabled = true;
            escolherNR10Button.Enabled = true;
            escolherNR33Button.Enabled = true;
            escolherNR35Button.Enabled = true;
            visitanteToggleSwitch.Enabled = true;
            adminToggleSwitch.Enabled = true;
            guardiaoToggleSwitch.Enabled = true;
            supervisorToggleSwitch.Enabled = true;
            usuarioTextBox.Enabled = true;
            senhaTextBox.Enabled = true;
            textBoxEmail.Enabled = true;
            textBoxRFID.Enabled = true;
            pictureBoxFoto.Enabled = true;
            excludeImageButton.Enabled = true;
        }

        private async void buttonCadastrar_Click(object sender, EventArgs e)
        {
            DisableAll();

            //show loading bar
            loadingBar.Visible = true;
            loadingBar.Value = 0;

            //wait 1 second
            await Task.Delay(1000);
            loadingBar.Value = 20;

            try
            {
                // Generate salt and hash if needed
                var salt = "";
                var hash = "";

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
                    Identificacao = Guid.NewGuid().ToString(),
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
                    IsAdmin = adminToggleSwitch.Checked,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    IsGuardian = guardiaoToggleSwitch.Checked,
                    Username = adminToggleSwitch.Checked == true ? usuarioTextBox.Text : "",
                    Salt = adminToggleSwitch.Checked == true ? salt : "",
                    Hash = adminToggleSwitch.Checked == true ? hash : "",
                    StartJob = dateTimePickerCheckin.Value,
                    EndJob = dateTimePickerCheckout.Value,
                    Email = textBoxEmail.Text ?? "",
                    Picture = pictureBoxFoto.Image != null ? "" : "",
                    RFID = textBoxRFID.Text ?? "",
                    Project = "",
                    IsVisitor = visitanteToggleSwitch.Checked,
                };

                // Create new authorization object
                Authorization newAuthorization = new Authorization
                {
                    Id = Guid.NewGuid(),
                    UserId = newUser.Identificacao,
                    ExpirationDate = newUser.EndJob,
                    // VesselId will be set after retrieving it from the VesselRepository
                };

                //get first saved vessel id from settings
                string vesselId = Properties.Settings.Default.VesselId.Split(',')[0];

                newAuthorization.VesselId = vesselId;

                // Add the authorization id to the  AuthorizationsId from the new user
                List<Guid> authorizationsId = new List<Guid>
                {
                    newAuthorization.Id
                };
                newUser.AuthorizationsId = authorizationsId.ToArray();
             
                // Save the user using UserRepository
               

                    var userCreationResult = await _userRepository.CreateUserAsync(newUser);
                    if (userCreationResult == false)
                    {
                        MessageBox.Show("Erro ao cadastrar usuário.");
                        return;
                    } else
                {
                    Event eventoCriacao = new Event
                    {
                        Id = Guid.NewGuid().ToString(),
                        PortalId = "portal1",
                        UserId = newUser.Identificacao,
                        VesselId = vesselId,
                        Action = 0,
                        Direction = 0,
                        Manual = false,
                        Status = "sync_pending",
                        Timestamp = DateTime.Now,
                        Picture = "",
                        Justification = ""
                    };

                    //post new event to api
                    EventRepository eventRepository = new EventRepository(apiService: new ApiService());
                    await eventRepository.CreateEventAsync(eventoCriacao);

                }

                // Save the authorization using AuthorizationRepository
                var authorizationCreationResult = await _authorizationRepository.CreateAuthorizationAsync(newAuthorization);
                    if (authorizationCreationResult == null)
                    {
                        MessageBox.Show("Erro ao criar autorização.");
                        return;
                    }
                

                await Task.Delay(500);
                loadingBar.Value = 40;

                await Task.Delay(500);
                loadingBar.Value = 60;

                SendRfidsOverSerialAsync(new List<string> { newUser.RFID });

                await Task.Delay(1000);
                loadingBar.Value = 100;

                MessageBox.Show("Usuário cadastrado com sucesso!");
                EnableAll();

                //switch to UC_Dados
                SwitchToDados?.Invoke();
            }
            catch (Exception ex)
            {
                EnableAll();
                loadingBar.Value = 0;
                loadingBar.Visible = false;
                UC_Error errorControl = new UC_Error(RetryUserRegistration, "Erro ao cadastrar o usuário, tente novamente.");
                errorControl.Location = new Point(600, 200); // Set appropriate location
                errorControl.Size = new Size(683, 397); // Set appropriate size
                this.Controls.Add(errorControl);
                errorControl.BringToFront();

                errorControl.Show();

            }
        }

        private async void RetryUserRegistration()
        {
            // Logic to retry user registration
            // For simplicity, I'm calling buttonCadastrar_Click again.
            // You might want to refactor the code inside buttonCadastrar_Click 
            // into a separate method and call that method here and inside buttonCadastrar_Click.
            buttonCadastrar_Click(this, EventArgs.Empty);
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

            if (isEditar)
            {
                // Show a popup to get the block reason
                using (var form = new Form())
                {
                    var textBox = new TextBox() { Width = 250, Height = 60 };
                    var buttonOk = new Button() { Text = "Ok", DialogResult = DialogResult.OK, Left = 170, Width = 60 };
                    var buttonCancel = new Button() { Text = "Cancel", DialogResult = DialogResult.Cancel, Left = 240, Width = 60 };

                    form.Text = "Block Reason";
                    form.Controls.Add(textBox);
                    form.Controls.Add(buttonOk);
                    form.Controls.Add(buttonCancel);
                    form.AcceptButton = buttonOk;
                    form.CancelButton = buttonCancel;
                    form.FormBorderStyle = FormBorderStyle.FixedDialog;
                    form.StartPosition = FormStartPosition.CenterScreen;

                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        string blockReason = textBox.Text;

                        // Call the method to block the user
                        BlockUser(blockReason);
                    }
                }
            }
            else
            {
                // Other registration logic for when not editing
            }
        }

        private async Task BlockUser(string blockReason)
        {
            try
            {
                // Assuming you have a selected user to blo
                var selectedUser = new User();

                selectedUser.IsBlocked = true;
                selectedUser.BlockReason = blockReason;


                //userId from instance of edited user.
                //var result = await _userRepository.BlockUserAsync(); // Replace UpdateAsync with your actual update method

             /*   if (result)
                {
                    MessageBox.Show("User blocked successfully.");
                }
                else
                {
                    MessageBox.Show("Failed to block the user.");
                }*/
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
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

        public Image byteArrayToImage(string byteArrayIn)
        {
            byte[] byteArray = Encoding.ASCII.GetBytes(byteArrayIn);
            MemoryStream ms = new MemoryStream(byteArray);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
        public void PopulateFields(User user)
        {
            isEditar = true;
            buttonCadastrar.Text = "Salvar";
            buttonRegistrar.Text = "Bloquear";
            buttonRegistrar.FillColor = Color.FromArgb(199, 0, 57);
            buttonRegistrar.CustomBorderColor = Color.FromArgb(199, 0, 57);
            buttonRegistrar.Enabled = true;
            buttonRegistrar.Image = null;
            textBoxNome.Text = user.Name;
            textBoxFuncao.Text = user.Role;
            textBoxEmpresa.Text = user.Company;
            labelNumero.Text = user.Number.ToString();
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
            textBoxRFID.Text = user.RFID;
            //byteArrayToImage(user.Picture);
            //pictureBoxFoto.Image = byteArrayToImage(user.Picture);
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
            if (adminToggleSwitch.Checked)
            {
                visitanteToggleSwitch.Checked = false;
                visitanteToggleSwitch.Enabled = false;
                usuarioLabel.Visible = true;
                usuarioPanel.Visible = true;
                usuarioReqLabel.Visible = true;
                usuarioTextBox.Visible = true;

                senhaLabel.Visible = true;
                senhaPanel.Visible = true;
                senhaReqLabel.Visible = true;
                senhaTextBox.Visible = true;
            }
            else
            {
                if (supervisorToggleSwitch.Checked)
                {
                    supervisorToggleSwitch.Checked = false;
                    usuarioLabel.Visible = false;
                    usuarioPanel.Visible = false;
                    usuarioReqLabel.Visible = false;
                    usuarioTextBox.Visible = false;

                    senhaLabel.Visible = false;
                    senhaPanel.Visible = false;
                    senhaReqLabel.Visible = false;
                    senhaTextBox.Visible = false;
                }
                else
                {
                    supervisorToggleSwitch.Checked = false;
                    visitanteToggleSwitch.Enabled = true;
                    usuarioLabel.Visible = false;
                    usuarioPanel.Visible = false;
                    usuarioReqLabel.Visible = false;
                    usuarioTextBox.Visible = false;

                    senhaLabel.Visible = false;
                    senhaPanel.Visible = false;
                    senhaReqLabel.Visible = false;
                    senhaTextBox.Visible = false;
                }
            }

            ValidateFields();
        }

        private void guardiaoToggleSwitch1_CheckedChanged(object sender, EventArgs e)
        {
            if (guardiaoToggleSwitch.Checked)
            {
                visitanteToggleSwitch.Checked = false;
                visitanteToggleSwitch.Enabled = false;
                usuarioLabel.Visible = true;
                usuarioPanel.Visible = true;
                usuarioReqLabel.Visible = true;
                usuarioTextBox.Visible = true;

                senhaLabel.Visible = true;
                senhaPanel.Visible = true;
                senhaReqLabel.Visible = true;
                senhaTextBox.Visible = true;
            }
            else
            {
                if (adminToggleSwitch.Checked == false)
                {
                    usuarioLabel.Visible = false;
                    usuarioPanel.Visible = false;
                    usuarioReqLabel.Visible = true;
                    usuarioReqLabel.Visible = false;
                    usuarioTextBox.Visible = false;

                    senhaLabel.Visible = false;
                    senhaPanel.Visible = false;
                    senhaReqLabel.Visible = false;
                    senhaTextBox.Visible = false;
                }
            }
        }

        private void supervisorToggleSwitch_CheckedChanged(object sender, EventArgs e)
        {
            if (supervisorToggleSwitch.Checked == true)
            {
                visitanteToggleSwitch.Checked = false;
                visitanteToggleSwitch.Enabled = false;
                adminToggleSwitch.Checked = true;
            }
            if (supervisorToggleSwitch.Checked && adminToggleSwitch.Checked)
            {
                adminToggleSwitch.Checked = false;
                usuarioLabel.Visible = true;
                usuarioPanel.Visible = true;
                usuarioReqLabel.Visible = true;
                usuarioTextBox.Visible = true;

                senhaLabel.Visible = true;
                senhaPanel.Visible = true;
                senhaReqLabel.Visible = true;
                senhaTextBox.Visible = true;
            }
            if (supervisorToggleSwitch.Checked == false)
            {
                visitanteToggleSwitch.Enabled = true;
                adminToggleSwitch.Checked = false;
                usuarioLabel.Visible = false;
                usuarioPanel.Visible = false;
                usuarioReqLabel.Visible = false;
                usuarioTextBox.Visible = false;

                senhaLabel.Visible = false;
                senhaPanel.Visible = false;
                senhaReqLabel.Visible = false;
                senhaTextBox.Visible = false;
            }

            ValidateFields();

        }

        private void textBoxRFID_TextChanged(object sender, EventArgs e)
        {
            string rfid = textBoxRFID.Text;
            if (!string.IsNullOrEmpty(rfid) && rfid.Length == 24)
            {
                textBoxRFID.ReadOnly = true;
                ValidateFields();

            }
            if (textBoxRFID.Text == "issupervisor")
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

        private void textBoxRFID_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBoxRFID.Text.Length < 24)
            {
                textBoxRFID.Text = "";
            }
        }

        private async void GetLastNumberAsync()
        {
            string lastNumber = await _userRepository.GetLastNumberAsync();
            lastNumber = lastNumber.Replace("\"", "");
            labelNumero.Text = lastNumber.ToString();
        }

        private async Task<List<string>> GetUsersRfidsByVesselAsync(string vesselId)
        {
            try
            {
                // Fetch the RFIDs from the repository
                var rfidsArray = await _userRepository.GetUsersRfidsByVesselAsync(vesselId);

                //show the rfids in a message box
                //MessageBox.Show(string.Join("\n", rfidsArray));
               // SendRfidsOverSerialAsync(rfidsArray.ToList());
                // Convert the array to a list and return
                return rfidsArray.ToList();
            }
            catch (Exception ex)
            {
                // Handle any exceptions here
                //MessageBox.Show($"Error fetching RFIDs: {ex.Message}");
                return new List<string>();  // Return an empty list in case of an error
            }
        }
        private void SendRfidsOverSerialAsync(List<string> rfids)
        {
            try
            {
                // Configure the serial port
                using (SerialPort serialPort = new SerialPort("COM3", 9600))
                {
                    serialPort.Open();

                    foreach (var rfid in rfids)
                    {

                        // Calculate checksum (sum of ASCII values of all characters % 256)
                        int checksum = rfid.Sum(c => (int)c) % 256;

                        // Append the checksum to the RFID string
                        string rfidToSend = rfid + "*" + checksum.ToString();

                      // MessageBox.Show(rfidToSend);
                        serialPort.WriteLine(rfidToSend);
                    

                       string received = serialPort.ReadLine();
                        int i = 0;
                       // MessageBox.Show(received);

                       /* while (!received.Contains(checksum.ToString()) && i < 5)
                        {
                            MessageBox.Show(rfidToSend);
                               serialPort.WriteLine(rfidToSend);
                            received = serialPort.ReadLine();
                            i++;
                        } */
                                            }
                    //wait 2 seconds before closing the serial port
                    for (int i = 0; i < 2; i++)
                    {
                        System.Threading.Thread.Sleep(1000);
                    }

                    serialPort.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error sending RFIDs over serial: {ex.Message}");
            }
        }
      
    }
}
