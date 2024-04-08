using DockCheckWindows.Repositories;
using DockCheckWindows.Services;
using DockCheckWindows.UserControls;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;

namespace DockCheckWindows
{
    public partial class Form1 : Form
    {
        private UC_Cadastrar uc_Cadastrar;

        private UC_Dados uc_Dados;

        private SerialPort serialPort;

        private AuthenticationRepository _authenticationRepository = new AuthenticationRepository(
                                   apiService: new ApiService()
                                                      );


        private UserRepository userRepository = new UserRepository(apiService: new ApiService());

        private VesselRepository vesselRepository = new VesselRepository(apiService: new ApiService());

        private EventRepository eventRepository = new EventRepository(apiService: new ApiService());

        private AuthorizationRepository authorizationRepository = new AuthorizationRepository(apiService: new ApiService());

        private SerialDataProcessor serialDataProcessor;

        public Form1()
        {
            CultureInfo newCulture = new CultureInfo("en");
            Thread.CurrentThread.CurrentCulture = newCulture;
            Thread.CurrentThread.CurrentUICulture = newCulture;
            String language = "en-US";
            Thread.CurrentThread.CurrentCulture = new CultureInfo(language);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

            InitializeComponent();

            serialOnOffButton.Click += new EventHandler(serialOnOffButton_Click);

            Login loginForm = new Login(
                authenticationRepository: _authenticationRepository
            );
            loginForm.ShowDialog();

            if (!loginForm.IsAuthenticated)
            {
                Application.Exit();
                return; // Add this to prevent further execution if not authenticated
            }

            serialDataProcessor = new SerialDataProcessor(eventRepository, userRepository, UpdateStatus);

            UC_Home home = new UC_Home();
            uc_Cadastrar = new UC_Cadastrar(
                userRepository: new UserRepository(apiService: new ApiService()),
                authorizationRepository: new AuthorizationRepository(apiService: new ApiService()),
                ucDados: new UC_Dados(uc_Cadastrar, userRepository: new UserRepository(apiService: new ApiService()), eventRepository: new EventRepository(apiService: new ApiService())),
                serialDataProcessor: serialDataProcessor
                );

            uc_Dados = new UC_Dados(uc_Cadastrar, userRepository: new UserRepository(apiService: new ApiService()), eventRepository: new EventRepository(apiService: new ApiService()));

            loggedUserName(Properties.Settings.Default.UserId);
            addUserControl(home);
            cadastroButton.Text = Properties.Resources.Cadastrar;
        }

        private System.Windows.Forms.Timer blinkTimer;

        private void InitializeBlinkTimer()
        {
            blinkTimer = new System.Windows.Forms.Timer();
            blinkTimer.Interval = 500; // Blink interval in milliseconds
            blinkTimer.Tick += BlinkTimer_Tick;
        }

        private void BlinkTimer_Tick(object sender, EventArgs e)
        {
            signalPictureBox.Visible = !signalPictureBox.Visible;
        }


        private void StartBlinking()
        {
           // InitializeBlinkTimer();
            signalPictureBox.Visible = true;
           // blinkTimer.Start();
        }

        private void StopBlinking()
        {
            //blinkTimer.Stop();
        }

        //retieve user object from user_id with UserRepository
        private async void loggedUserName(String userId)
        {
            var user = await userRepository.GetUserByIdAsync(userId);
            Console.WriteLine("User: " + user.ToJson());

            labelUser.Text = user.Name;
            Properties.Settings.Default.Name = user.Name;
            Properties.Settings.Default.Save();
        }

        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            foreach (Control control in panelContainer.Controls)
            {
                if (control != uc_Cadastrar)  // Skip disposing of uc_Cadastrar
                {
                    control.Dispose();
                }
            }
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void homeButton_Click(object sender, EventArgs e)
        {
            UC_Home home = new UC_Home();
            addUserControl(home);
        }

        private void cadastroButton_Click(object sender, EventArgs e)
        {
            UC_Cadastrar cadastrar = new UC_Cadastrar(
                userRepository: new UserRepository(apiService: new ApiService()),
                authorizationRepository: new AuthorizationRepository(apiService: new ApiService()),
                ucDados: new UC_Dados(uc_Cadastrar, userRepository: new UserRepository(apiService: new ApiService()), eventRepository: new EventRepository(apiService: new ApiService())),
                serialDataProcessor: serialDataProcessor
                );
            cadastrar.SwitchToDados += () =>
            {
                addUserControl(uc_Dados);
            };
            addUserControl(cadastrar);
        }

        private void dashboardButton_Click(object sender, EventArgs e)
        {
            UC_Dashboard dashboard = new UC_Dashboard();
            addUserControl(dashboard);
        }

        private void bancoButton_Click(object sender, EventArgs e)
        {
            UC_Dados dados = new UC_Dados(uc_Cadastrar, userRepository: new UserRepository(apiService: new ApiService()), eventRepository: new EventRepository(apiService: new ApiService()));  // Pass the instance field
            dados.SwitchToCadastro += () =>
            {
                addUserControl(uc_Cadastrar);
            };
            addUserControl(dados);
        }

        private void cameraButton_Click(object sender, EventArgs e)
        {
            UC_Cameras cameras = new UC_Cameras();
            addUserControl(cameras);
        }

        private async void fecharButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Token = "";
            Properties.Settings.Default.Save();

            Console.WriteLine(Properties.Settings.Default.Token);
            Console.WriteLine(Properties.Settings.Default.UserId);

            await _authenticationRepository.LogoutAsync(Properties.Settings.Default.UserId);
        }

        private void UpdateStatus(string message)
        {
            // Check for UI thread and invoke if necessary
            if (InvokeRequired)
            {
                Invoke(new Action(() => UpdateStatus(message)));
                return;
            }
            signalLabel.Text = message;
            /*
            // Update the UI based on the message
            if (message.Contains("P"))
            {
                StartBlinking();
                signalLabel.Text = message;
            }
            else if (message.Contains("Receiving") || message.Contains("Sending"))
            {
                signalLabel.Text = message;
            }
            else if (message.Contains("Data processing completed"))
            {
                // Reset or update the label when data processing is completed
               // signalLabel.Text = "----------------";
                signalLabel.Text = message;
                StopBlinking();
            }
            */
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            // Retrieve authorization from settings
            string authorization = Properties.Settings.Default.Authorization;

            // Check if the authorization string is null or empty
            if (string.IsNullOrEmpty(authorization))
            {
                return; // Exit the method if there is no authorization data
            }

            signalLabel.Text = "-------------------------------";
            signalPictureBox.Visible = true;

            // Split the authorizations by comma
            var authorizationIds = authorization.Split(',');

            List<string> vesselNames = new List<string>();
            List<string> vesselIds = new List<string>();

            foreach (var authId in authorizationIds)
            {
                var authorizationComplete = await authorizationRepository.GetAuthorizationByIdAsync(authId);
                if (authorizationComplete != null)
                {
                    string vesselId = authorizationComplete.VesselId;
                    var vessel = await vesselRepository.GetVesselByIdAsync(vesselId);
                    if (vessel != null)
                    {
                        // Save the Vessel Name, Vessel IDs into our settings
                        vesselNames.Add(vessel.Name);
                        vesselIds.Add(vessel.Id);
                        vesselLabel.Text = vessel.Name;
                    }

                    Properties.Settings.Default.Vessel = string.Join(",", vesselNames);
                    Properties.Settings.Default.VesselId = string.Join(",", vesselIds);
                    Properties.Settings.Default.Save();

                    await serialDataProcessor.StartProcessingAsync();
                }
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            blinkTimer?.Dispose();
        }

        private void serialOnOffButton_Click(object sender, EventArgs e)
        {
            serialDataProcessor.PauseProcessing();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await serialDataProcessor.ResumeProcessingAsync();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
