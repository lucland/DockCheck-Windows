using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DockCheckWindows.Models;
using DockCheckWindows.Repositories;
using DockCheckWindows.Services;
using Guna.UI2.WinForms;

namespace DockCheckWindows.UserControls
{
    public partial class UC_Cadastrar : UserControl
    {
        public event Action SwitchToDados;

        private SerialPort _serialPort;
        private UC_Dados _ucDados;
        private UserRepository _userRepository;
        private AuthorizationRepository _authorizationRepository;
        private PicRepository _picRepository = new PicRepository(new ApiService());
        private EventRepository _eventRepository = new EventRepository(new ApiService());
        private User _currentUser;
        private bool _isEditMode;
        private string _area = "Convés";

        public UC_Cadastrar(UserRepository userRepository,
                            AuthorizationRepository authorizationRepository, UC_Dados ucDados)
        {
            InitializeComponent();

            _ucDados = ucDados;
            AttachEventHandlers();
            InitializeDateTimePickers();
            InitializeButtonStates();
            InitializeRepositories(userRepository, authorizationRepository);
            InitializeRegistrationProcess();
        }

        public async void PopulateFields(User user)
        {
            var pic = await _picRepository.GetPictureAsync(user.Identificacao);

            _isEditMode = true;
            _currentUser = user;

            buttonRegistrar.Enabled = true;
            buttonRegistrar.Image = null;

            labelNumero.Text = user.Number.ToString();
            textBoxNome.Text = user.Name;
            textBoxFuncao.Text = user.Role;
            textBoxEmpresa.Text = user.Company;
            maskedTextBoxIdentidade.Text = user.Identidade;
            maskedTextBoxCpf.Text = user.CPF;
            maskedTextBoxAso.Text = user.ASO != DateTime.MinValue ? user.ASO.ToString("dd/MM/yyyy") : "";
            maskedTextBoxNr34.Text = user.NR34 != DateTime.MinValue ? user.NR34.ToString("dd/MM/yyyy") : "";
            maskedTextBoxNr10.Text = user.NR10 != DateTime.MinValue ? user.NR10.ToString("dd/MM/yyyy") : "";
            maskedTextBoxNr33.Text = user.NR33 != DateTime.MinValue ? user.NR33.ToString("dd/MM/yyyy") : "";
            maskedTextBoxNr35.Text = user.NR35 != DateTime.MinValue ? user.NR35.ToString("dd/MM/yyyy") : "";
            dateTimePickerCheckin.Value = user.StartJob;
            dateTimePickerCheckout.Value = user.EndJob;
            adminToggleSwitch.Checked = user.IsAdmin;
            guardiaoToggleSwitch.Checked = user.IsGuardian;
            usuarioTextBox.Text = user.Username;
            senhaTextBox.Text = user.Hash;
            textBoxEmail.Text = user.Email;
            textBoxRFID.Text = user.RFID;
            pictureBoxFoto.Image = pic.Picture != "" ? ConvertBase64ToImage(pic.Picture) : null;
            excludeImageButton.Visible = user.Picture != "" && pic.Picture != "";
            visitanteToggleSwitch.Checked = user.IsVisitor;

            if (user.Area == "Convés")
            {
                buttonConves.Checked = true;
                buttonCasaDeMaquinas.Checked = false;
                buttonCasario.Checked = false;
                _area = "Convés";
            }
            else if (user.Area == "Casa de Máquinas")
            {
                buttonConves.Checked = false;
                buttonCasaDeMaquinas.Checked = true;
                buttonCasario.Checked = false;
                _area = "Casa de Máquinas";
            }
            else if (user.Area == "Casario")
            {
                buttonConves.Checked = false;
                buttonCasaDeMaquinas.Checked = false;
                buttonCasario.Checked = true;
                _area = "Casario";
            }

            buttonCadastrar.Text = "Salvar";
            buttonRegistrar.Text = "Cancelar";

            // Optionally, handle the visibility or enabled state of other controls
        }

        private void AttachEventHandlers()
        {
            TextBox[] textBoxes = { textBoxNome, textBoxFuncao, textBoxEmpresa };
            foreach (var textBox in textBoxes)
            {
                textBox.TextChanged += (sender, e) => ValidateFields();
            }

            MaskedTextBox[] maskedTextBoxes = { maskedTextBoxIdentidade, maskedTextBoxCpf, maskedTextBoxAso, maskedTextBoxNr34 };
            foreach (var maskedTextBox in maskedTextBoxes)
            {
                maskedTextBox.TextChanged += (sender, e) => ValidateFields();
            }

            Guna2DateTimePicker[] dateTimePickers = { dateTimePickerCheckin, dateTimePickerCheckout };
            foreach (var dateTimePicker in dateTimePickers)
            {
                dateTimePicker.ValueChanged += (sender, e) => ValidateFields();
            }

            visitanteToggleSwitch.CheckedChanged += (sender, e) => ValidateFields();
            adminToggleSwitch.CheckedChanged += (sender, e) => ValidateFields();
            guardiaoToggleSwitch.CheckedChanged += (sender, e) => ValidateFields();
            supervisorToggleSwitch.CheckedChanged += (sender, e) => ValidateFields();
            usuarioTextBox.TextChanged += (sender, e) => ValidateFields();
            senhaTextBox.TextChanged += (sender, e) => ValidateFields();
            textBoxRFID.TextChanged += (sender, e) => ValidateFields();
        }

        private void InitializeDateTimePickers()
        {
            dateTimePickerCheckin.Value = dateTimePickerCheckout.Value = DateTime.Today;
        }

        private void InitializeButtonStates()
        {
            if (_isEditMode)
            {
               buttonRegistrar.Enabled = true;
                buttonRegistrar.Image = null;
                buttonCadastrar.Enabled = false;
            } else
            {
                bloquearButton.Enabled = false;
                buttonCadastrar.Enabled = buttonRegistrar.Enabled = false;
                excludeImageButton.Visible = false;
            }
        }

        private void InitializeRepositories(UserRepository userRepository,
                                            AuthorizationRepository authorizationRepository)
        {
            _userRepository = userRepository;
            _authorizationRepository = authorizationRepository;
        }

        private async void InitializeRegistrationProcess()
        {
            if (!_isEditMode)
            {
              //  var vesselIds = Properties.Settings.Default.VesselId.Split(',') ?? "";
              //  var vesselId = vesselIds[0] ?? "";

                await GetLastNumberAsync();
               // await GetUsersRfidsByVesselAsync(vesselId);
            }
        }

        private void ValidateFields()
        {
            bool areFieldsFilled = AreBasicFieldsFilled() &&
                                   AreDocumentDatesValid() &&
                                   IsPhotoUploaded() &&
                                   IsAdminOrSupervisorFieldsValid();

            buttonCadastrar.Enabled = areFieldsFilled;
            if (!_isEditMode)
            {
                buttonRegistrar.Enabled = areFieldsFilled && IsRfidValid();
            }
        }

        private bool AreBasicFieldsFilled()
        {
            return !string.IsNullOrEmpty(textBoxNome.Text) &&
                   !string.IsNullOrEmpty(textBoxFuncao.Text) &&
                   maskedTextBoxIdentidade.Text.Length == 9 &&
                   !string.IsNullOrEmpty(textBoxEmpresa.Text) &&
                   maskedTextBoxCpf.Text.Length == 11;
        }

        private bool AreDocumentDatesValid()
        {
            return (visitanteToggleSwitch.Checked || IsAsoDateValid()) &&
                   (visitanteToggleSwitch.Checked || IsNr34DateValid()) &&
                   dateTimePickerCheckin.Value.Date >= DateTime.Today &&
                   dateTimePickerCheckout.Value.Date >= DateTime.Today &&
                   dateTimePickerCheckin.Value.Date <= dateTimePickerCheckout.Value.Date;
        }

        private bool IsAsoDateValid()
        {
            return DateTime.TryParseExact(maskedTextBoxAso.Text, "dd/MM/yyyy", null, DateTimeStyles.None, out DateTime asoDate) && asoDate > DateTime.Today;
        }

        private bool IsNr34DateValid()
        {
            return DateTime.TryParseExact(maskedTextBoxNr34.Text, "dd/MM/yyyy", null, DateTimeStyles.None, out DateTime nr34Date) && nr34Date > DateTime.Today;
        }

        private bool IsPhotoUploaded()
        {
            return pictureBoxFoto.Image != null;
        }

        private bool IsAdminOrSupervisorFieldsValid()
        {
            return !adminToggleSwitch.Checked || (!string.IsNullOrEmpty(usuarioTextBox.Text) && !string.IsNullOrEmpty(senhaTextBox.Text));
        }

        private bool IsRfidValid()
        {
          //  return textBoxRFID.Text.Length == 24;
          return true;
        }


        private string ConvertImageToBase64(PictureBox pictureBox)
        {
            //compress image first to reduce size
            if (pictureBox == null)
            {
                   return "";
            } else
            {
                var compressedImage = CompressImage(pictureBox.Image);
                using (MemoryStream ms = new MemoryStream())
                {
                    compressedImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] imageBytes = ms.ToArray();
                    return Convert.ToBase64String(imageBytes);
                }
            }
        }

        private Image CompressImage(Image originalImage)
        {
            // Define the maximum size you want to allow (e.g., 800x600)
            int maxWidth = 800;
            int maxHeight = 600;

            // Compute the new size maintaining the aspect ratio
            var ratioX = (double)maxWidth / originalImage.Width;
            var ratioY = (double)maxHeight / originalImage.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(originalImage.Width * ratio);
            var newHeight = (int)(originalImage.Height * ratio);

            // Create a new bitmap with the new size and draw the original image onto it
            var newImage = new Bitmap(newWidth, newHeight);
            using (var graphics = Graphics.FromImage(newImage))
            {
                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighSpeed;
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
                graphics.DrawImage(originalImage, 0, 0, newWidth, newHeight);
            }

            return newImage;
        }
        private async Task BlockUser(string blockReason, string userId)
        {
            try
            {
                var result = await _userRepository.BlockUserAsync(userId: userId, blockReason: blockReason);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private async Task GetLastNumberAsync()
        {
            try
            {
                string lastNumber = await _userRepository.GetLastNumberAsync();
                labelNumero.Text = lastNumber.Trim('\"');
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching last number: {ex.Message}");
            }
        }

        private async Task<List<string>> GetUsersRfidsByVesselAsync(string vesselId)
        {
            try
            {
                var rfidsArray = await _userRepository.GetUsersRfidsByVesselAsync(vesselId);
                return rfidsArray.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching RFIDs: {ex.Message}");
                return new List<string>();
            }
        }

        private async Task SendRfidsOverSerialAsync(List<string> rfids)
        {
            try
            {
                using (_serialPort = new SerialPort("COM3", 9600))
                {
                    _serialPort.Open();
                    foreach (var rfid in rfids)
                    {
                        int checksum = CalculateChecksum(rfid);
                        string rfidToSend = $"{rfid}*{checksum}";
                        _serialPort.WriteLine(rfidToSend);
                    }
                    await Task.Delay(2000);
                    _serialPort.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error sending RFIDs over serial: {ex.Message}");
            }
        }

        private int CalculateChecksum(string data)
        {
            return data.Sum(c => c) % 256;
        }

        // Button click handlers
        private void buttonConves_Click(object sender, EventArgs e)
        {
            ToggleButtonState(buttonConves, true);
            ToggleButtonState(buttonCasaDeMaquinas, false);
            ToggleButtonState(buttonCasario, false);
            _area = "Convés";
        }

        private void buttonCasaDeMaquinas_Click(object sender, EventArgs e)
        {
            ToggleButtonState(buttonConves, false);
            ToggleButtonState(buttonCasaDeMaquinas, true);
            ToggleButtonState(buttonCasario, false);
            _area = "Casa de Máquinas";
        }

        private void buttonCasario_Click(object sender, EventArgs e)
        {
            ToggleButtonState(buttonConves, false);
            ToggleButtonState(buttonCasaDeMaquinas, false);
            ToggleButtonState(buttonCasario, true);
            _area = "Casario";
        }

        private void ToggleButtonState(Guna2Button button, bool state)
        {
            button.Checked = state;
        }

        private async void buttonCadastrar_Click(object sender, EventArgs e)
        {
            if (_isEditMode)
            {
                UpdateUser(_currentUser);
            }
            else
            {
                DisableAll();
                ShowLoadingBar();

                try
                {
                    await RegisterUserAsync();
                    CompleteRegistration();
                }
                catch (Exception ex)
                {
                    HandleRegistrationError(ex);
                }
            }
        }

        private void ShowLoadingBar()
        {
            loadingBar.Visible = true;
            loadingBar.Value = 0;
        }

        private async Task RegisterUserAsync()
        {
            UpdateLoadingBar(10);

            if (!ValidateUserInput())
            {
                MessageBox.Show("Invalid user input.");
                throw new InvalidOperationException("Invalid user input.");
            }

            User newUser = CreateUserObject();
            Authorization newAuthorization = CreateAuthorizationObject(newUser);

            UpdateLoadingBar(20);

            Pic newPic = new Pic
            {
                Id = Guid.NewGuid().ToString(),
                UserId = newUser.Identificacao,
                Picture = ConvertImageToBase64(pictureBoxFoto),
            };

            bool isPictureUploaded = await UploadPictureAsync(newPic);
            if (!isPictureUploaded)
            {
                MessageBox.Show("Failed to upload picture.");
                Console.WriteLine("Failed to upload picture.");
                throw new InvalidOperationException("Failed to upload picture.");
            }

            UpdateLoadingBar(40);

            bool isUserCreated = await SaveUserAsync(newUser);
            if (!isUserCreated)
            {
                MessageBox.Show("Failed to create user.");
                Console.WriteLine("Failed to create user.");
                throw new InvalidOperationException("Failed to create user.");
            }

            UpdateLoadingBar(60);

            bool isAuthorizationCreated = await SaveAuthorizationAsync(newAuthorization);
            if (!isAuthorizationCreated)
            {
                MessageBox.Show("Failed to create authorization.");
                Console.WriteLine("Failed to create authorization.");
                throw new InvalidOperationException("Failed to create authorization.");
            }

            UpdateLoadingBar(80);

            var ev = new Event
            {
                Id = Guid.NewGuid().ToString(),
                Action = 0,
                PortalId = "0",
                Timestamp = DateTime.Now,
                UserId = newUser.Identificacao,
                VesselId = Properties.Settings.Default.VesselId.Split(',')[0],
                Direction = 0,
                Manual = false,
                Picture = "",
                Status = "sync_pending",
                Justification = "",
            };

            bool isEventCreated = await SaveEventAsync(ev);
            if (!isEventCreated)
            {
                MessageBox.Show("Failed to create event.");
                Console.WriteLine("Failed to create event.");
                throw new InvalidOperationException("Failed to create event.");
            }

          //  await SendRfidsOverSerialAsync(new List<string> { newUser.RFID });

            

            UpdateLoadingBar(100);
        }

        private bool ValidateUserInput()
        {
            return !string.IsNullOrEmpty(textBoxNome.Text) &&
                   !string.IsNullOrEmpty(textBoxFuncao.Text) &&
                   maskedTextBoxIdentidade.Text.Length == 9 &&
                   !string.IsNullOrEmpty(textBoxEmpresa.Text) &&
                   maskedTextBoxCpf.Text.Length == 11 &&
                   (visitanteToggleSwitch.Checked || IsAsoDateValid()) &&
                   (visitanteToggleSwitch.Checked || IsNr34DateValid()) &&
                   dateTimePickerCheckin.Value.Date >= DateTime.Today &&
                   dateTimePickerCheckout.Value.Date >= DateTime.Today &&
                   dateTimePickerCheckin.Value.Date <= dateTimePickerCheckout.Value.Date &&
                   IsAdminOrSupervisorFieldsValid() &&
                   IsRfidValid();
        }

        private User CreateUserObject()
        {
            DateTime nr10Date;
            bool nr10DateParsed = DateTime.TryParseExact(maskedTextBoxNr10.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out nr10Date);

            DateTime nr33Date;
            bool nr33DateParsed = DateTime.TryParseExact(maskedTextBoxNr33.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out nr33Date);

            DateTime nr35Date;
            bool nr35DateParsed = DateTime.TryParseExact(maskedTextBoxNr35.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out nr35Date);

            return new User
            {
                Name = textBoxNome.Text,
                Role = textBoxFuncao.Text,
                Company = textBoxEmpresa.Text,
                Identidade = maskedTextBoxIdentidade.Text.Replace(" ", ""),
                Events = new string[] { },
                CPF = maskedTextBoxCpf.Text.Replace(" ", ""),
                ASO = IsAsoDateValid() ? DateTime.ParseExact(maskedTextBoxAso.Text, "dd/MM/yyyy", null) : DateTime.MinValue,
                NR34 = IsNr34DateValid() ? DateTime.ParseExact(maskedTextBoxNr34.Text, "dd/MM/yyyy", null) : DateTime.MinValue,
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
                StartJob = dateTimePickerCheckin.Value,
                EndJob = dateTimePickerCheckout.Value,
                Email = textBoxEmail.Text ?? "",
                Picture = "",
                RFID = textBoxRFID.Text ?? "",
                Project = "",
                IsVisitor = visitanteToggleSwitch.Checked,
                Salt = "",
                Hash = adminToggleSwitch.Checked ? senhaTextBox.Text : "",
                Status = "sync_pending",
                Identificacao = Guid.NewGuid().ToString(),
                BlockReason = "",
                IsBlocked = false,
                Area = _area,
                TypeJob = "",
            };
        }

        private Authorization CreateAuthorizationObject(User user)
        {
            return new Authorization
            {
                UserId = user.Identificacao,
                ExpirationDate = dateTimePickerCheckout.Value,
                VesselId = Properties.Settings.Default.VesselId.Split(',')[0],
                Status = "sync_pending",
                Id = Guid.NewGuid(),
            };
        }

        private async Task<bool> SaveUserAsync(User user)
        {
            try
            {
                return await _userRepository.CreateUserAsync(user);
            }
            catch (Exception ex)
            {
                //print error message
                MessageBox.Show($"Error: {ex.Message}");
                return false;
            }
        }

        private async Task<bool> SaveEventAsync(Event ev)
        {
            try
            {
                var result = await _eventRepository.CreateEventAsync(ev);
                return result != null;
            }
            catch (Exception ex)
            {
                //print error message
                MessageBox.Show($"Error: {ex.Message}");
                return false;
            }
        }

        private async Task<bool> SaveAuthorizationAsync(Authorization authorization)
        {
            try
            {
               var auth =  await _authorizationRepository.CreateAuthorizationAsync(authorization);
                return auth != null;
            }
            catch (Exception ex)
            {
                //print error message
                MessageBox.Show($"Error: {ex.Message}");
                return false;
            }
        }

        //UploadPictureAsync
        private async Task<bool> UploadPictureAsync(Pic picture)
        {
            try
            {
                if (picture.Picture != "")
                {
                   var result = await _picRepository.AddPictureAsync(picture);
                    return result != null;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                //print error message
                MessageBox.Show($"Error: {ex.Message}");
                return false;
            }
        }

        //get picture from database
        private async Task<Pic> GetPictureAsync(string userId)
        {
            try
            {
                return await _picRepository.GetPictureAsync(userId);
            }
            catch (Exception ex)
            {
                //print error message
                MessageBox.Show($"Error: {ex.Message}");
                return null;
            }
        }

        private void UpdateLoadingBar(int value)
        {
            loadingBar.Value = value;
        }

        private void CompleteRegistration()
        {
            MessageBox.Show("Usuário cadastrado com sucesso!");
            EnableAll();
            SwitchToDados?.Invoke();
        }

        private void HandleRegistrationError(Exception ex)
        {
            EnableAll();
            loadingBar.Value = 0;
            loadingBar.Visible = false;
            DisplayErrorControl("Erro ao cadastrar o usuário, tente novamente.", ex.Message);
        }

        private void DisplayErrorControl(string message, string errorMessage)
        {
            var errorControl = new UC_Error(RetryUserRegistration, errorMessage);
            errorControl.Location = new Point(600, 200);
            errorControl.Size = new Size(683, 397);
            Controls.Add(errorControl);
            errorControl.BringToFront();
            errorControl.Show();
        }

        //RetryUserRegistration
        private async void RetryUserRegistration()
        {
            DisableAll();
            ShowLoadingBar();

            try
            {
                await RegisterUserAsync();
                CompleteRegistration();
            }
            catch (Exception ex)
            {
                HandleRegistrationError(ex);
            }
        }

        public Image ConvertBase64ToImage(string base64String)
        {
            byte[] imageBytes = Convert.FromBase64String(base64String);
            using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                Image image = Image.FromStream(ms, true);
                return image;
            }
        }

        private async void UpdateUser(User user)
        {
            DateTime nr10Date;
            bool nr10DateParsed = DateTime.TryParseExact(maskedTextBoxNr10.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out nr10Date);

            DateTime nr33Date;
            bool nr33DateParsed = DateTime.TryParseExact(maskedTextBoxNr33.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out nr33Date);

            DateTime nr35Date;
            bool nr35DateParsed = DateTime.TryParseExact(maskedTextBoxNr35.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out nr35Date);


            // Update user with the new data from fields
            user.Name = textBoxNome.Text;
            user.Role = textBoxFuncao.Text;
            user.Company = textBoxEmpresa.Text;
            user.Identidade = maskedTextBoxIdentidade.Text.Replace(" ", "");
            user.CPF = maskedTextBoxCpf.Text.Replace(" ", "");
            user.ASO = IsAsoDateValid() ? DateTime.ParseExact(maskedTextBoxAso.Text, "dd/MM/yyyy", null) : DateTime.MinValue;
            user.NR34 = IsNr34DateValid() ? DateTime.ParseExact(maskedTextBoxNr34.Text, "dd/MM/yyyy", null) : DateTime.MinValue;
            user.Number = int.Parse(labelNumero.Text);
            user.HasNR10 = maskedTextBoxNr10.Text != "";
            user.NR10 = nr10DateParsed ? nr10Date : DateTime.MinValue;
            user.HasNR33 = maskedTextBoxNr33.Text != "";
            user.NR33 = nr33DateParsed ? nr33Date : DateTime.MinValue;
            user.HasNR35 = maskedTextBoxNr35.Text != "";
            user.NR35 = nr35DateParsed ? nr35Date : DateTime.MinValue;
            user.HasASO = maskedTextBoxAso.Text != "";
            user.ASODocument = escolherASOButton.Text ?? "";
            user.NR34Document = escolherNR34Button.Text ?? "";
            user.NR35Document = escolherNR35Button.Text ?? "";
            user.NR33Document = escolherNR33Button.Text ?? "";
            user.NR10Document = escolherNR10Button.Text ?? "";
            user.IsAdmin = adminToggleSwitch.Checked;
            user.UpdatedAt = DateTime.Now;
            user.IsGuardian = guardiaoToggleSwitch.Checked;
            user.Username = adminToggleSwitch.Checked == true ? usuarioTextBox.Text : "";
            user.StartJob = dateTimePickerCheckin.Value;
            user.EndJob = dateTimePickerCheckout.Value;
            user.Email = textBoxEmail.Text ?? "";
            user.Picture = pictureBoxFoto.Image != null ? ConvertImageToBase64(pictureBoxFoto) : "";
            user.RFID = textBoxRFID.Text ?? "";
            user.Project = "";
            user.IsVisitor = visitanteToggleSwitch.Checked;
            user.TypeJob = "";
            user.Area = _area;

            // Save changes to the database
            await _userRepository.UpdateUserAsync(user);

            //close the edit form
            SwitchToDados?.Invoke();
        }

        private void RevertChanges()
        {    
           SwitchToDados?.Invoke();
        }


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

        private async void buttonRegistrar_Click(object sender, EventArgs e)
        {
            if (_isEditMode)
            {
                SwitchToDados?.Invoke();
            }
            else
            {
                DisableAll();
                ShowLoadingBar();

                try
                {
                    await RegisterUserAsync();
                    CompleteRegistration();
                }
                catch (Exception ex)
                {
                    HandleRegistrationError(ex);
                }
            }
        }

        private void HandleCancelInEditMode()
        {
            // Revert changes to the user object
            RevertChanges();
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

        private void adminToggleSwitch_CheckedChanged(object sender, EventArgs e)
        {
            UpdateUserAndPasswordFieldsVisibility(adminToggleSwitch.Checked || guardiaoToggleSwitch.Checked);
            UpdateToggleSwitchesState();
            ValidateFields();
        }

        private void guardiaoToggleSwitch_CheckedChanged(object sender, EventArgs e)
        {
            UpdateUserAndPasswordFieldsVisibility(guardiaoToggleSwitch.Checked);
            UpdateToggleSwitchesState();
            ValidateFields();
        }

        private void supervisorToggleSwitch_CheckedChanged(object sender, EventArgs e)
        {
            if (supervisorToggleSwitch.Checked)
            {
                adminToggleSwitch.Checked = true;
            }
            UpdateUserAndPasswordFieldsVisibility(adminToggleSwitch.Checked);
            UpdateToggleSwitchesState();
            ValidateFields();
        }

        private void UpdateUserAndPasswordFieldsVisibility(bool isVisible)
        {
            usuarioLabel.Visible = isVisible;
            usuarioPanel.Visible = isVisible;
            usuarioReqLabel.Visible = isVisible;
            usuarioTextBox.Visible = isVisible;

            senhaLabel.Visible = isVisible;
            senhaPanel.Visible = isVisible;
            senhaReqLabel.Visible = isVisible;
            senhaTextBox.Visible = isVisible;
        }

        private void UpdateToggleSwitchesState()
        {
            if (!adminToggleSwitch.Checked && !guardiaoToggleSwitch.Checked)
            {
                visitanteToggleSwitch.Enabled = true;
            }
            else
            {
                visitanteToggleSwitch.Checked = false;
                visitanteToggleSwitch.Enabled = false;
            }
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

        private async void bloquearButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(motivoTextBox.Text))
            {
                MessageBox.Show("Por favor, insira um motivo para bloquear o usuário.");
            }
            else
            {
                await BlockUser(motivoTextBox.Text, _currentUser.Identificacao);
                SwitchToDados?.Invoke();
            }
        }

        private void motivoTextBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(motivoTextBox.Text))
            {
                bloquearButton.Enabled = false;
            }
            else
            {
                bloquearButton.Enabled = true;
            }
        }
    }
}
