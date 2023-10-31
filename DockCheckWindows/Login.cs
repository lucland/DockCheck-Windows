using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace DockCheckWindows
{
    public partial class Login : Form
    {
        public bool IsAuthenticated { get; private set; }


        public Login()
        {
            InitializeComponent();
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

            var apiService = new ApiService();
            var payload = new
            {
                username,
                password,
                role,
                system
            };

            string jsonPayload = Newtonsoft.Json.JsonConvert.SerializeObject(payload);

            string response = await apiService.PostDataAsync("http://your_backend.com/api/v1/login", jsonPayload);

            if (response != null)
            {
                JObject jsonResult = JObject.Parse(response);
                string token = jsonResult["token"].ToString();

                IsAuthenticated = true;

                Properties.Settings.Default.Token = token;
                Properties.Settings.Default.Save();

                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }

        private void textBoxUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxSenha_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelSenha_Click(object sender, EventArgs e)
        {

        }

        private void labelUsuario_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
