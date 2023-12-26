using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DockCheckWindows.Repositories;
using Newtonsoft.Json.Linq;

namespace DockCheckWindows
{
    public partial class Login : Form
    {
        private readonly AuthenticationRepository _authenticationRepository;

        public bool IsAuthenticated { get; private set; }
        public string Token { get; private set; }

        public Login(AuthenticationRepository authenticationRepository)
        {
            InitializeComponent();
            _authenticationRepository = authenticationRepository;
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
                ProcessLoginResponse(response);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void ProcessLoginResponse(string response)
        {
            if (string.IsNullOrEmpty(response))
            {
                MessageBox.Show("Invalid username or password.");
                return;
            }

            dynamic jsonResult = JObject.Parse(response);
            Token = jsonResult.token;
            IsAuthenticated = true;
            UpdatePropertiesSettings(jsonResult);
            this.Close();
        }

        private void UpdatePropertiesSettings(dynamic jsonResult)
        {
            Properties.Settings.Default.Token = Token;
            var authorizations = jsonResult.authorizations_id.ToObject<List<string>>();
            Properties.Settings.Default.Authorization = string.Join(",", authorizations);
            Properties.Settings.Default.UserId = jsonResult.user_id.ToString();
            Properties.Settings.Default.Save();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Close();
            Application.Exit();
        }
    }
}
