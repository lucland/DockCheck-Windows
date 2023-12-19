using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DockCheckWindows.Repositories;
using DockCheckWindows.Services;
using Newtonsoft.Json;
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
            Close();
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

                    Properties.Settings.Default.Token = Token;
                    Properties.Settings.Default.Save();

                    // Save authorization IDs from login response
                    var authorizations = jsonResult.authorizations_id.ToObject<List<string>>();
                    Properties.Settings.Default.Authorization = string.Join(",", authorizations); // Join the array into a comma-separated string
                    Properties.Settings.Default.Save();

                    // Save user_id from login response
                    Properties.Settings.Default.UserId = jsonResult.user_id.ToString();
                    Properties.Settings.Default.Save();

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
