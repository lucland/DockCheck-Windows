﻿using System.Collections.Generic;
using System.Threading.Tasks;
using DockCheckWindows.Services;
using Newtonsoft.Json;

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

        public async Task<string> GetAllUsersAsync(int limit = 99, int offset = 0)
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

        public async Task<string> SearchUsersAsync(string searchTerm, int page = 1, int pageSize = 10)
        {
            string url = $"{BaseUrl}/search?searchTerm={searchTerm}&page={page}&pageSize={pageSize}";
            return await GetAsync(url);
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            string url = $"{BaseUrl}/update/{user.Identificacao}";
            string data = user.ToJson();
            string response = await PutAsync(url, data, "User");
            return !string.IsNullOrEmpty(response);
        }

        public async Task<string> GetLastNumberAsync()
        {
            string url = $"{BaseUrl}/all/lastnumber";
            return await GetAsync(url);
        }

        public async Task<string[]> GetUsersRfidsByVesselAsync(string vesselId)
        {
            string url = $"{BaseUrl}/valids/{vesselId}";
            string jsonResponse = await GetAsync(url);

            // Assuming the response is a JSON array of strings (RFIDs)
            return JsonConvert.DeserializeObject<string[]>(jsonResponse);
        }

        public async Task<bool> BlockUserAsync(string userId, string blockReason)
        {
            string url = $"{BaseUrl}/block/{userId}";
            var data = new {blockReason};
            string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            string response = await PutAsync(url, jsonData, "User");
            return !string.IsNullOrEmpty(response);
        }
        public async Task<List<string>> GetAllBlockedUsersAsync()
        {
            string url = $"{BaseUrl}/all/blocked";
            string jsonResponse = await GetAsync(url);
            var blockedUserIds = JsonConvert.DeserializeObject<List<string>>(jsonResponse);
            return blockedUserIds;
        }

        public async Task<string> GetAllApprovedUsersAsync(int page = 1, int pageSize = 10)
        {
            string url = $"{BaseUrl}/all/approved?page={page}&pageSize={pageSize}";
            return await GetAsync(url);
        }
    }
}
