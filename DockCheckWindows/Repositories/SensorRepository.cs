using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DockCheckWindows.Models;
using DockCheckWindows.Services;
using Newtonsoft.Json;

namespace DockCheckWindows.Repositories
{
    public class SensorRepository : BaseRepository<Employee>
    {
        private readonly string BaseUrl = GlobalConfig.BaseApiUrl + "/sensors";
        private static readonly ApiService apiService = new ApiService();

        public SensorRepository(ApiService apiService)
            : base(apiService)
        {
        }

        //get all sensors
        public async Task<List<Sensor>> GetAllSensorsAsync(int limit = 1000, int offset = 0)
        {
            string url = $"{BaseUrl}?limit={limit}&offset={offset}";
            string jsonResponse = await GetAsync(url);
            return JsonConvert.DeserializeObject<List<Sensor>>(jsonResponse);
        }

        //update sensor with put baseUrl passing sensor id and json data
        public async Task UpdateSensorAsync(string id, Sensor sensor)
        {
            string url = $"{BaseUrl}/{id}";
            string data = JsonConvert.SerializeObject(sensor);
            await PutAsync(url, data, "Sensor");
        }

        //create sensor with post baseUrl passing json data
        public async Task<Sensor> CreateSensorAsync(Sensor sensor)
        {
            string url = $"{BaseUrl}/create";
            string data = JsonConvert.SerializeObject(sensor);
            string response = await apiService.PostDataAsync(url, data);
            return JsonConvert.DeserializeObject<Sensor>(response);
        }

        //get sensor by id
        public async Task<Sensor> GetSensorAsync(string id)
        {
            string url = $"{BaseUrl}/{id}";
            string jsonResponse = await GetAsync(url);
            return JsonConvert.DeserializeObject<Sensor>(jsonResponse);
        }

    }
}
