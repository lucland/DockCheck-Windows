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
        private DocumentRepository _documentRepository = new DocumentRepository(new ApiService());
        private EmployeeRepository _employeeRepository = new EmployeeRepository(new ApiService());
        private Employee _currentEmployee;
        private bool _isEditMode;
        private string _area = "Convés";
       // private SerialDataProcessor _serialDataProcessor;

        public UC_Cadastrar(UserRepository userRepository,
                            AuthorizationRepository authorizationRepository, UC_Dados ucDados,
                            DocumentRepository documentRepository, EventRepository eventRepository)
        {
            InitializeComponent();

            _ucDados = ucDados;
            _userRepository = userRepository;
            _authorizationRepository = authorizationRepository;
            _documentRepository = documentRepository;
            _eventRepository = eventRepository;
            AttachEventHandlers();
            InitializeButtonStates();
            InitializeRepositories(userRepository, authorizationRepository);
            InitializeRegistrationProcess();
          //  _serialDataProcessor = serialDataProcessor;
        }

        public async void PopulateFields(Employee employee)
        {
          //  var pic = await _picRepository.GetPictureAsync(employee.Identificacao);

            _isEditMode = true;
            _currentEmployee = employee;

            buttonRegistrar.Enabled = true;
            buttonRegistrar.Image = null;

            labelNumero.Text = employee.Number.ToString();
            textBoxNome.Text = employee.Name;
            textBoxFuncao.Text = employee.Role;
            textBoxEmpresa.Text = employee.ThirdCompanyId;
            sangueComboBox.Text = employee.BloodType;
            maskedTextBoxCpf.Text = employee.Cpf.ToString();
            textBoxEmail.Text = employee.Email;
            textBoxRFID.Text = employee.LastAreaFound;
            excludeImageButton.Visible = false;

            if (employee.Area == "Convés")
            {
                buttonEmbarcacao.Checked = true;
                buttonDiqueSeco.Checked = false;
                buttonAmbas.Checked = false;
                _area = "Convés";
            }
            else if (employee.Area == "Casa de Máquinas")
            {
                buttonEmbarcacao.Checked = false;
                buttonDiqueSeco.Checked = true;
                buttonAmbas.Checked = false;
                _area = "Casa de Máquinas";
            }
            else if (employee.Area == "Casario")
            {
                buttonEmbarcacao.Checked = false;
                buttonDiqueSeco.Checked = false;
                buttonAmbas.Checked = true;
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

            MaskedTextBox[] maskedTextBoxes = {maskedTextBoxCpf, maskedTextBoxAso, maskedTextBoxNr34 };
            foreach (var maskedTextBox in maskedTextBoxes)
            {
                maskedTextBox.TextChanged += (sender, e) => ValidateFields();
            }

            sangueComboBox.SelectedIndexChanged += (sender, e) => ValidateFields();

            visitanteToggleSwitch.CheckedChanged += (sender, e) => ValidateFields();
            textBoxRFID.TextChanged += (sender, e) => ValidateFields();
        }

        private void InitializeButtonStates()
        {
            if (_isEditMode)
            {
               buttonRegistrar.Enabled = true;
                buttonRegistrar.Image = null;
                buttonCadastrar.Enabled = false;
                motivoTextBox.Enabled = true;
            } else
            {
                motivoTextBox.Enabled = false;
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
            bool areFieldsFilled = AreBasicFieldsFilled();
                // &&

                              //     AreDocumentDatesValid() &&
                               //    IsPhotoUploaded() &&
                                 //  IsAdminOrSupervisorFieldsValid();

           // buttonCadastrar.Enabled = areFieldsFilled;
            buttonCadastrar.Enabled = true;
            buttonRegistrar.Enabled = true;
            if (!_isEditMode)
            {
                //buttonRegistrar.Enabled = areFieldsFilled && IsRfidValid();
            }
        }

        private bool AreBasicFieldsFilled()
        {
            return !string.IsNullOrEmpty(textBoxNome.Text) &&
                   !string.IsNullOrEmpty(textBoxFuncao.Text) &&
                   !string.IsNullOrEmpty(textBoxEmpresa.Text) &&
                   maskedTextBoxCpf.Text.Length == 11;
        }

        private bool AreDocumentDatesValid()
        {
            return (visitanteToggleSwitch.Checked || IsAsoDateValid()) &&
                   (visitanteToggleSwitch.Checked || IsNr34DateValid());
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
                int lastNumber = await _employeeRepository.GetLastNumberAsync();
                string lastNumberString = lastNumber.ToString();
   
                labelNumero.Text = lastNumberString.Trim('\"');
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching last number: {ex.Message}");
            }
        }

        private async Task SendRfidsOverSerialAsync(List<string> rfids)
        {
            try
            {
                using (_serialPort = new SerialPort("COM5", 115200))
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
            ToggleButtonState(buttonEmbarcacao, true);
            ToggleButtonState(buttonDiqueSeco, false);
            ToggleButtonState(buttonAmbas, false);
            _area = "Convés";
        }

        private void buttonCasaDeMaquinas_Click(object sender, EventArgs e)
        {
            ToggleButtonState(buttonEmbarcacao, false);
            ToggleButtonState(buttonDiqueSeco, true);
            ToggleButtonState(buttonAmbas, false);
            _area = "Casa de Máquinas";
        }

        private void buttonCasario_Click(object sender, EventArgs e)
        {
            ToggleButtonState(buttonEmbarcacao, false);
            ToggleButtonState(buttonDiqueSeco, false);
            ToggleButtonState(buttonAmbas, true);
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
                UpdateUser(_currentEmployee);
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

            Employee newUser = CreateEmployeeObject();
            UpdateLoadingBar(20);

            Pic newPic = new Pic
            {
                Id = Guid.NewGuid().ToString(),
                UserId = newUser.Id,
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
            //create Documents objects from ASO, NR-34 and if any additional documents are added based on the comboBox index beign zero or greater, then add them to the list of documents as well
            List<Document> documents = new List<Document>
            {
                new Document
                {
                    Id = Guid.NewGuid().ToString(),
                    EmployeeId = newUser.Id,
                    Type = "ASO",
                    ExpirationDate = DateTime.ParseExact(maskedTextBoxAso.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Status = "sync_pending",
                },
                new Document
                {
                    Id = Guid.NewGuid().ToString(),
                    EmployeeId = newUser.Id,
                    Type = "NR-34",
                    ExpirationDate = DateTime.ParseExact(maskedTextBoxNr34.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Status = "sync_pending",
                }
            };
            if (documentoAddComboBox1.SelectedIndex > 0)
            {
                documents.Add(new Document
                {
                    Id = Guid.NewGuid().ToString(),
                    EmployeeId = newUser.Id,
                    Type = documentoAddComboBox1.Text,
                    ExpirationDate = DateTime.ParseExact(maskedTextBoxAso.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Status = "sync_pending",
                });
            }
            if (documentoAddComboBox2.SelectedIndex > 0)
            {
                documents.Add(new Document
                {
                    Id = Guid.NewGuid().ToString(),
                    EmployeeId = newUser.Id,
                    Type = documentoAddComboBox2.Text,
                    ExpirationDate = DateTime.ParseExact(maskedTextBoxAso.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Status = "sync_pending",
                });
            }
            if (documentoAddComboBox3.SelectedIndex > 0)
            {
                documents.Add(new Document
                {
                    Id = Guid.NewGuid().ToString(),
                    EmployeeId = newUser.Id,
                    Type = documentoAddComboBox3.Text,
                    ExpirationDate = DateTime.ParseExact(maskedTextBoxAso.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Status = "sync_pending",
                });
            }
            if (documentoAddComboBox4.SelectedIndex > 0)
            {
                documents.Add(new Document
                {
                    Id = Guid.NewGuid().ToString(),
                    EmployeeId = newUser.Id,
                    Type = documentoAddComboBox4.Text,
                    ExpirationDate = DateTime.ParseExact(maskedTextBoxAso.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Status = "sync_pending",
                });
            }
            //send documents to the API using the DocumentRepository
            foreach (var document in documents)
            {
                bool isDocumentCreated = await _documentRepository.CreateDocumentAsync(document);
                if (!isDocumentCreated)
                {
                    MessageBox.Show("Failed to create document.");
                    Console.WriteLine("Failed to create document.");
                }
            }
            UpdateLoadingBar(80);
            try
            {
               // await _serialDataProcessor.SendApprovedIdAsync("P0", newUser.Area); // Replace "SlavePC" with the actual PC identifier
                UpdateLoadingBar(95);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error sending iTag to slaves: {ex.Message}");
                // Handle error (you might want to stop the process or just log the error)
            }
            try
            {
             /*   if (newUser.Area != "")
                {
                    await _serialDataProcessor.SendApprovedIdAsync("P0", newUser.Area); // Replace "SlavePC" with the actual PC identifier
                }*/
            } catch (Exception ex)
            {
                MessageBox.Show($"Error sending iTag to slaves: {ex.Message}");
            }
            var ev = new Event
            {
                Id = Guid.NewGuid().ToString(),
                Action = 0,
                SensorId = "0",
                Timestamp = DateTime.Now,
                EmployeeId = newUser.Id,
                ProjectId = Properties.Settings.Default.VesselId.Split(',')[0],
                BeaconId = "",
                Status = "sync_pending",
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
                   !string.IsNullOrEmpty(textBoxEmpresa.Text) &&
                   maskedTextBoxCpf.Text.Length == 11 &&
                   (visitanteToggleSwitch.Checked || IsAsoDateValid()) &&
                   (visitanteToggleSwitch.Checked || IsNr34DateValid()) &&
                   IsRfidValid();
        }

        private Employee CreateEmployeeObject()
        {
            return new Employee
            {
                Name = textBoxNome.Text,
                Role = textBoxFuncao.Text,
                ThirdCompanyId = textBoxEmpresa.Text,
                BloodType = sangueComboBox.Text.Trim(),
                Cpf = maskedTextBoxCpf.Text.Replace(" ", ""),
                Number = int.Parse(labelNumero.Text),
                Email = textBoxEmail.Text ?? "",
                Area = textBoxRFID.Text ?? "",
                Status = "sync_pending",
                Id = Guid.NewGuid().ToString(),
                BlockReason = "",
                IsBlocked = false,
                Telephone = textBoxTelefone.Text ?? "",
            };
        }

        private async Task<bool> SaveUserAsync(Employee employee)
        {
            try
            {
                return await _employeeRepository.CreateEmployeeAsync(employee);
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

        private async void UpdateUser(Employee employee)
        {

            // Update user with the new data from fields
            employee.Name = textBoxNome.Text;
            employee.Role = textBoxFuncao.Text;
            employee.ThirdCompanyId = textBoxEmpresa.Text;
            employee.BloodType = sangueComboBox.Text.Trim();
            employee.VisitorCompany = "";
            employee.AuthorizationsId = new List<string>();
            employee.UserId = Properties.Settings.Default.UserId;
            employee.Cpf = maskedTextBoxCpf.Text.Replace(" ", "");
            employee.Number = int.Parse(labelNumero.Text);
            employee.Email = textBoxEmail.Text;
            employee.Area = textBoxRFID.Text;
            employee.Status = "updated windows";
            employee.BlockReason = "";
            employee.IsBlocked = false;
            employee.LastAreaFound = textBoxRFID.Text;
            employee.LastTimeFound = DateTime.Now;
            employee.DocumentsOk = true;

            // Save changes to the database
            await _employeeRepository.UpdateEmployeeAsync(employee.Id, textBoxRFID.Text);

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
            sangueComboBox.Enabled = false;
            maskedTextBoxCpf.Enabled = false;
            maskedTextBoxAso.Enabled = false;
            maskedTextBoxNr34.Enabled = false;
            buttonCadastrar.Enabled = false;
            buttonRegistrar.Enabled = false;
            buttonEmbarcacao.Enabled = false;
            buttonDiqueSeco.Enabled = false;
            buttonAmbas.Enabled = false;
            uploadButton.Enabled = false;
            capturaButton.Enabled = false;
            escolherASOButton.Enabled = false;
            escolherNR34Button.Enabled = false;
            visitanteToggleSwitch.Enabled = false;
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
            sangueComboBox.Enabled = true;
            maskedTextBoxCpf.Enabled = true;
            maskedTextBoxAso.Enabled = true;
            maskedTextBoxNr34.Enabled = true;
            buttonCadastrar.Enabled = true;
            buttonRegistrar.Enabled = true;
            buttonEmbarcacao.Enabled = true;
            buttonDiqueSeco.Enabled = true;
            buttonAmbas.Enabled = true;
            uploadButton.Enabled = true;
            capturaButton.Enabled = true;
            escolherASOButton.Enabled = true;
            escolherNR34Button.Enabled = true;
            visitanteToggleSwitch.Enabled = true;
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

        private async void lerTagButton_Click(object sender, EventArgs e)
        {
         /*   try
            {
                // _serialDataProcessor.PauseProcessing();

                // Ensure port is fully released before attempting to open
                // await Task.Delay(1000);
                _serialDataProcessor.PauseProcessing();
                _serialDataProcessor.PauseProcessing();
                _serialDataProcessor.PauseProcessing();
                _serialDataProcessor.PauseProcessing();

                if (_serialPort == null)
                {
                    _serialPort = new SerialPort("COM5", 115200)
                    {
                        ReadTimeout = 5000,
                        WriteTimeout = 500
                    };
                }

                if (!_serialPort.IsOpen)
                {
                    _serialPort.Open();
                }
                _serialPort.WriteLine("L2");
                await Task.Delay(1000);

                _serialPort.WriteLine("L1"); // Command to read RFID tag

                await Task.Delay(1000); // Wait for response

                while (_serialPort.IsOpen && _serialPort.BytesToRead > 0)
                {
                    string rfid = _serialPort.ReadLine();
                    textBoxRFID.Text = rfid;
                    _serialPort.WriteLine("L2");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            finally
            {
                if (_serialPort.IsOpen)
                {
                    _serialPort.Close();
                }
             //   await _serialDataProcessor.ResumeProcessingAsync();
            }*/
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


        private void textBoxRFID_TextChanged(object sender, EventArgs e)
        {
            
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
                await BlockUser(motivoTextBox.Text, _currentEmployee.Id);
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

        private void DisplayEtiquetaControl()
        {
            //TODO: get vessel name from user authorization
            string vesselName = "Skandi Salvador";
            var ucEtiqueta = new UC_Etiqueta(
                name: textBox2.Text,
                identificacao: textBoxNumber.Text,
                embarcacao: vesselName,
                empresa: textBoxEmpresa.Text,
                checkin: DateTime.Now.ToString("dd/MM/yyyy"),
                role: textBox1.Text,
                checkout: "-"
                );
            ucEtiqueta.Location = new Point(800, 300);
            ucEtiqueta.Size = new Size(353, 288);
            Controls.Add(ucEtiqueta);
            ucEtiqueta.BringToFront();
            ucEtiqueta.Show();
        }

        private void printButton_Click(object sender, EventArgs e)
        {
            DisplayEtiquetaControl();
        }

        private void labelNumero_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void documentoAddComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if index is positive or zero, enable the button
            if (documentoAddComboBox1.SelectedIndex >= 0)
            {
                escolherDocButton1.Enabled = true;
            }
            else
            {
                escolherDocButton1.Enabled = false;
            }
        }

        private void documentoAddComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if index is positive or zero, enable the button
            if (documentoAddComboBox2.SelectedIndex >= 0)
            {
                escolherDocButton2.Enabled = true;
            }
            else
            {
                escolherDocButton2.Enabled = false;
            }

        }

        private void documentoAddComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if index is positive or zero, enable the button
            if (documentoAddComboBox3.SelectedIndex >= 0)
            {
                escolherDocButton3.Enabled = true;
            }
            else
            {
                escolherDocButton3.Enabled = false;
            }

        }

        private void documentoAddComboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if index is positive or zero, enable the button
            if (documentoAddComboBox4.SelectedIndex >= 0)
            {
                escolherDocButton4.Enabled = true;
            }
            else
            {
                escolherDocButton4.Enabled = false;
            }

        }

        private void maskedTextBoxNr34_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void escolherDocButton1_Click(object sender, EventArgs e)
        {
            //choose file and display the name of it on label4
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PDF files (*.pdf) | *.pdf";
            openFileDialog.FilterIndex = 0;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //show only the file name instead of the whole path of it
                if (string.IsNullOrEmpty(escolherDocButton1.Text))
                {
                    escolherDocButton1.Text = openFileDialog.SafeFileName;
                }
                else
                {
                    escolherDocButton1.Text += "\n" + openFileDialog.SafeFileName;
                }
            }

            ValidateFields();
        }

        private void escolherDocButton2_Click(object sender, EventArgs e)
        {
            //choose file and display the name of it on label4
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PDF files (*.pdf) | *.pdf";
            openFileDialog.FilterIndex = 0;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //show only the file name instead of the whole path of it
                if (string.IsNullOrEmpty(escolherDocButton2.Text))
                {
                    escolherDocButton2.Text = openFileDialog.SafeFileName;
                }
                else
                {
                    escolherDocButton2.Text += "\n" + openFileDialog.SafeFileName;
                }
            }

            ValidateFields();
        }

        private void escolherDocButton3_Click(object sender, EventArgs e)
        {
            //choose file and display the name of it on label4
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PDF files (*.pdf) | *.pdf";
            openFileDialog.FilterIndex = 0;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //show only the file name instead of the whole path of it
                if (string.IsNullOrEmpty(escolherDocButton3.Text))
                {
                    escolherDocButton3.Text = openFileDialog.SafeFileName;
                }
                else
                {
                    escolherDocButton3.Text += "\n" + openFileDialog.SafeFileName;
                }
            }

            ValidateFields();
        }

        private void escolherDocButton4_Click(object sender, EventArgs e)
        {
            //choose file and display the name of it on label4
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PDF files (*.pdf) | *.pdf";
            openFileDialog.FilterIndex = 0;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //show only the file name instead of the whole path of it
                if (string.IsNullOrEmpty(escolherDocButton4.Text))
                {
                    escolherDocButton4.Text = openFileDialog.SafeFileName;
                }
                else
                {
                    escolherDocButton4.Text += "\n" + openFileDialog.SafeFileName;
                }
            }

            ValidateFields();
        }

        private void labelVisitante_Click(object sender, EventArgs e)
        {

        }
    }
}
