using DockCheckWindows.Services;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DockCheckWindows.Repositories
{
    public class AuthenticationRepository
    {
        private readonly ApiService _apiService;
        private const string LoginUrl = "http://localhost:3000/api/v1/login";
        private const string LogoutUrl = "http://localhost:3000/api/v1/login/logout";

        public AuthenticationRepository(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<string> LoginAsync(string username, string password, string role, string system)
        {
            var loginData = new
            {
                username,
                password,
                role,
                system
            };
            var json = JsonConvert.SerializeObject(loginData);
            var response = await _apiService.PostDataAsync(LoginUrl, json);
            return response;
        }

        public async Task<string> LogoutAsync(string user_id)
        {
            var logoutData = new
            {
                user_id
            };
            var json = JsonConvert.SerializeObject(logoutData);
            var response = await _apiService.PostDataAsync(LogoutUrl, json);
            //remove the token and userId from settings
            Properties.Settings.Default.Token = "";
            Properties.Settings.Default.Save();
            Console.WriteLine(response);
            if (response != null && response.Contains("Successfully logged out"))
            {
                Properties.Settings.Default.UserId = "";
                Properties.Settings.Default.Save();
                Console.WriteLine("settings of UserId " + Properties.Settings.Default.UserId);
                Application.Exit();
                return "OK";
            }
            else
            {
                MessageBox.Show("Erro ao fazer logout");
                return "ERROR";
            }
        }
    }
}
