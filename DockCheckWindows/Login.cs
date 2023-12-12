using System;
using System.Windows.Forms;
using DockCheckWindows.Repositories;
using DockCheckWindows.Services;
using Newtonsoft.Json.Linq;

namespace DockCheckWindows
{
    public partial class Login : Form
    {
        private readonly AuthenticationRepository _authenticationRepository;

        public bool IsAuthenticated { get; private set; }
        public string Token { get; private set; } // Token property to store the JWT token

        public Login(AuthenticationRepository authenticationRepository)
        {
            InitializeComponent();
            _authenticationRepository = authenticationRepository;
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private async void buttonLogin_Click(object sender, EventArgs e)
        {
            string username = textBoxUsuario.Text;
            string password = textBoxSenha.Text;
            string role = comboBoxRole.Text;
            string system = "windows";

            try
            {
                string response = await _authenticationRepository.LoginAsync(username, password, role, system);

                if (!string.IsNullOrEmpty(response))
                {
                    dynamic jsonResult = JObject.Parse(response);
                    Token = jsonResult.token;

                    IsAuthenticated = true;

                    // Store the token in a static property or a settings file if needed
                    // For example, using Properties.Settings:
                    Properties.Settings.Default.Token = Token;
                    Properties.Settings.Default.Save();

                    //save authorization from login
                    Properties.Settings.Default.Authorization = jsonResult.authorizations_id;
                    Console.WriteLine("Authorization: " + jsonResult.aut);


                    //save user_id from login
                    Properties.Settings.Default.UserId = jsonResult.user_id;
                    Console.WriteLine("User id: " + jsonResult.user_id);
                    Properties.Settings.Default.Save();
                    Console.WriteLine("settings of UserId " + Properties.Settings.Default.UserId);

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid username or password.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
