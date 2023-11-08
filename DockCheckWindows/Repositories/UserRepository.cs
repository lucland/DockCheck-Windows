﻿using System.Threading.Tasks;
using DockCheckWindows.Models;
using DockCheckWindows.Services;
using Newtonsoft.Json.Linq;

namespace DockCheckWindows.Repositories
{
    public class UserRepository : BaseRepository<User>
    {
        private const string BaseUrl = "http://localhost:3000/api/v1/users";
        private static readonly ApiService apiService = new ApiService();

        public UserRepository(ApiService apiService)
            : base(apiService)
        {
        }

        public async Task<User> GetUserByIdAsync(string id)
        {
            string url = $"{BaseUrl}/{id}";
            string jsonResponse = await GetAsync(url);
            return User.FromJson(jsonResponse);
        }

        public async Task<string> GetAllUsersAsync(int limit = 10, int offset = 0)
        {
            string url = $"{BaseUrl}?limit={limit}&offset={offset}";
            return await GetAsync(url);
        }

        public async Task<bool> CreateUserAsync(User user)
        {
            string url = $"{BaseUrl}/create";
            string data = user.ToJson();
            string response = await PostAsync(url, data, "User");
            return !string.IsNullOrEmpty(response);
        }

        public async Task<string> GetUserAuthorizationsByIdAsync(string userId)
        {
            string url = $"{BaseUrl}/{userId}/authorizations";
            return await GetAsync(url);
        }

        public async Task<bool> CheckUsernameAsync(string username)
        {
            string url = $"{BaseUrl}/checkUsername";
            var data = new {username};
            string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            string response = await PostAsync(url, jsonData, "usernames");
            JObject jsonResponse = JObject.Parse(response);
            string message = jsonResponse["message"].ToString();
            return message == "Username available";
        }
    }
}
