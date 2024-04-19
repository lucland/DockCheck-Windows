using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DockCheckWindows.Models;
using DockCheckWindows.Services;
using Newtonsoft.Json;

namespace DockCheckWindows.Repositories
{
    public class UserRepository : BaseRepository<User>
    {
        private readonly string BaseUrl = GlobalConfig.BaseApiUrl + "/users";
        private static readonly ApiService apiService = new ApiService();

        public UserRepository(ApiService apiService)
            : base(apiService)
        {
        }

        public async Task<User> GetUserAsync(string id)
        {
            string url = $"{BaseUrl}/{id}";
            string jsonResponse = await GetAsync(url);
            return JsonConvert.DeserializeObject<User>(jsonResponse);
        }

        public async Task<bool> CreateUserAsync(User user)
        {
            string url = $"{BaseUrl}/create";
            string data = JsonConvert.SerializeObject(user);
            string response = await apiService.PostDataAsync(url, data);
            return !string.IsNullOrEmpty(response);
        }

        public async Task<User> UpdateUserAsync(string id, User user)
        {
            string url = $"{BaseUrl}/update/{id}";
            string data = JsonConvert.SerializeObject(user);
            string response = await apiService.PutDataAsync(url, data);
            return JsonConvert.DeserializeObject<User>(response);
        }

        public async Task DeleteUserAsync(string id)
        {
            string url = $"{BaseUrl}/{id}";
            await apiService.DeleteDataAsync(url);
        }

        public async Task<List<User>> GetAllUsersAsync(int limit = 1000, int offset = 0)
        {
            string url = $"{BaseUrl}?limit={limit}&offset={offset}";
            string jsonResponse = await GetAsync(url);
            return JsonConvert.DeserializeObject<List<User>>(jsonResponse);
        }

        public async Task<List<Authorization>> GetUserAuthorizationsAsync(string userId)
        {
            string url = $"{BaseUrl}/{userId}/authorizations";
            string jsonResponse = await GetAsync(url);
            return JsonConvert.DeserializeObject<List<Authorization>>(jsonResponse);
        }

        public async Task<bool> CheckUsernameAvailabilityAsync(string username)
        {
            string url = $"{BaseUrl}/checkUsername";
            var data = new { username };
            string jsonData = JsonConvert.SerializeObject(data);
            string response = await apiService.PostDataAsync(url, jsonData);
            return response == "Username available";
        }

        public async Task<List<User>> SearchUsersAsync(string searchTerm, int page = 1, int pageSize = 10)
        {
            string url = $"http://172.20.255.223:3000/api/v1/users/search?searchTerm={searchTerm}&page={page}&pageSize={pageSize}";
            string jsonResponse = await apiService.GetWithoutTokenAsync(url);
            return JsonConvert.DeserializeObject<List<User>>(jsonResponse);
        }

        public async Task<int> GetLastUserNumberAsync()
        {
            string url = $"{BaseUrl}/getNextUserNumber";
            string response = await apiService.GetWithoutTokenAsync(url);
            return int.Parse(response);
        }

        public async Task<List<string>> GetValidUsersByVesselIdAsync(string vesselId)
        {
            string url = $"{BaseUrl}/valids/{vesselId}";
            string jsonResponse = await GetAsync(url);
            return JsonConvert.DeserializeObject<List<string>>(jsonResponse);
        }

        public async Task<List<string>> GetUsersIdsFromServerAsync()
        {
            string url = $"{BaseUrl}/ids";
            string jsonResponse = await GetAsync(url);
            return JsonConvert.DeserializeObject<List<string>>(jsonResponse);
        }

        public async Task<User> GetUserByBeaconAsync(string id)
        {
            string url = $"{BaseUrl}/user/rfid/{id}";
            string jsonResponse = await GetAsync(url);
            return JsonConvert.DeserializeObject<User>(jsonResponse);
        }
    }
}
