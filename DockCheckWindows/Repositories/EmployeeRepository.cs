﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DockCheckWindows.Models;
using DockCheckWindows.Services;
using Newtonsoft.Json;

namespace DockCheckWindows.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>
    {
        private readonly string BaseUrl = GlobalConfig.BaseApiUrl + "/employees";
        private static readonly ApiService apiService = new ApiService();

        public EmployeeRepository(ApiService apiService)
            : base(apiService)
        {
        }

        public async Task<Employee> GetUserAsync(string id)
        {
            string url = $"{BaseUrl}/byid/{id}";
            string jsonResponse = await GetAsync(url);
            return JsonConvert.DeserializeObject<Employee>(jsonResponse);
        }

        public async Task<bool> CreateEmployeeAsync(Employee employee)
        {
            string url = $"{BaseUrl}/create";
            string data = JsonConvert.SerializeObject(employee);
            string response = await apiService.PostDataAsync(url, data);
            return !string.IsNullOrEmpty(response);
        }
        public async Task<ApprovedEmployeesResponse> GetAllApprovedEmployeesAsync(int limit = 1000, int offset = 0)
        {
            string url = $"{BaseUrl}?limit={limit}&offset={offset}";
            string jsonResponse = await GetAsync(url);
            var employees = JsonConvert.DeserializeObject<List<Employee>>(jsonResponse);

            // Refactor employees into ApprovedEmployeesResponse object
            var response = new ApprovedEmployeesResponse
            {
                Ids = employees.Select(e => e.Id).ToList(),
                CurrentPage = 1, // Assuming we're on the first page
                PageSize = employees.Count,
                TotalCount = employees.Count,
                TotalPages = 1 // Assuming only one page for simplicity
            };

            return response;
        }

        public async Task<Employee> UpdateEmployeeAsync(string id, string lastAreaFound)
        {
            string url = $"{BaseUrl}/updateEmployeeLastAreaFound/{id}";
            // data is a JSON { "last_area_found": itag };
            string data = JsonConvert.SerializeObject(new { last_area_found = lastAreaFound });
            string response = await apiService.PutDataAsync(url, data);
            Console.WriteLine(response);
            Console.WriteLine(data);
            Console.WriteLine(url);
            Console.WriteLine(id);
            Console.WriteLine(lastAreaFound);
                return JsonConvert.DeserializeObject<Employee>(response);
        }

        public async Task DeleteUserAsync(string id)
        {
            string url = $"{BaseUrl}/{id}";
            await apiService.DeleteDataAsync(url);
        }

        public async Task<List<Employee>> GetAllEmployeeAsync(int limit = 1000, int offset = 0)
        {
            string url = $"{BaseUrl}/all/";
            string jsonResponse = await GetAsync(url);
            return JsonConvert.DeserializeObject<List<Employee>>(jsonResponse);
        }

        public async Task<List<Employee>> GetAllEmployeeOnboardedAsync(int limit = 1000, int offset = 0)
        {
            string url = $"{BaseUrl}/lastarea";
            string jsonResponse = await GetAsync(url);
            Console.WriteLine(jsonResponse);
            Console.WriteLine(JsonConvert.DeserializeObject<List<Employee>>(jsonResponse));
            return JsonConvert.DeserializeObject<List<Employee>>(jsonResponse);
        }

        public async Task<List<Daily>> GetAllEmployeeDailiesAsync()
        {
            string url = $"{GlobalConfig.BaseApiUrl}/dailies/";
            string jsonResponse = await GetAsync(url);
            Console.WriteLine(jsonResponse);
            Console.WriteLine(JsonConvert.DeserializeObject<List<Employee>>(jsonResponse));
            return JsonConvert.DeserializeObject<List<Daily>>(jsonResponse);
        }

        public async Task<List<Authorization>> GetEmployeeAuthorizationsAsync(string userId)
        {
            string url = $"{BaseUrl}/{userId}/authorizations";
            string jsonResponse = await GetAsync(url);
            return JsonConvert.DeserializeObject<List<Authorization>>(jsonResponse);
        }

        public async Task<Employee> GetUserByBeaconAsync(string id)
        {
            string url = $"{BaseUrl}/user/rfid/{id}";
            string jsonResponse = await GetAsync(url);
            return JsonConvert.DeserializeObject<Employee>(jsonResponse);
        }

        //GetLastNumberAsync
        public async Task<int> GetLastNumberAsync()
        {
            string url = $"{BaseUrl}/number/lastnumber";
            string jsonResponse = await GetAsync(url);
            return int.Parse(jsonResponse);
        }
        //create a call get /areas that return a list of string
        public async Task<string> GetAreasAsync()
        {
            string url = $"{BaseUrl}/areas";
            string jsonResponse = await GetAsync(url);
            return JsonConvert.DeserializeObject<string>(jsonResponse);
        }

        //update area by employee id passing body as area:value to '/area/:id'
        public async Task UpdateAreaAsync(string id, string area)
        {
            string url = $"{BaseUrl}/area/{id}";
            string data = JsonConvert.SerializeObject(new { area });
            string response = await PutAsyncNoDB(url, data);

            // Check for specific error messages
            if (response != null && response.StartsWith("Error:"))
            {
                // Extract the status code
                var statusCode = response.Split(' ')[1];
                if (statusCode == "400")
                {
                    MessageBox.Show("Beacon ID já está em uso. Por favor, insira um Beacon válido.");
                }
                else
                {
                    MessageBox.Show("Erro ao atualizar a área do funcionário. Tente novamente.");
                }
            }
            else if (response == "-")
            {
                MessageBox.Show("Erro de comunicação com o servidor. Tente novamente.");
            }
        }


    }
}
