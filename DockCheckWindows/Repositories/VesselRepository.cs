using DockCheckWindows.Models;
using DockCheckWindows.Services;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DockCheckWindows.Repositories
{
    public class VesselRepository : BaseRepository<Vessel>
    {
        // private const string BaseUrl = "http://localhost:3000/api/v1/vessels";
        private string BaseUrl = GlobalConfig.BaseApiUrl + "/vessels";

        public VesselRepository(ApiService apiService)
            : base(apiService)
        {
        }

        public async Task<Vessel> GetVesselByIdAsync(string id)
        {
            var json = await GetAsync($"{BaseUrl}/{id}");
            return JsonConvert.DeserializeObject<Vessel>(json);
        }

        public async Task<string> GetAllVesselsAsync()
        { 
            return await GetAsync(BaseUrl + "/company/company123");
        }

        public async Task<Vessel> CreateVesselAsync(Vessel vessel)
        {
            var json = JsonConvert.SerializeObject(vessel);
            var response = await PostAsync(BaseUrl, json, "Vessel");
            return JsonConvert.DeserializeObject<Vessel>(response);
        }

        public async Task<List<Event>> GetEventsByVesselIdAsync(string vesselId, int limit = 50, int offset = 0)
        {
            string url = $"{BaseUrl}/events/{vesselId}?limit={limit}&offset={offset}";
            var json = await GetAsync(url);
            return JsonConvert.DeserializeObject<List<Event>>(json);
        }
        //onboarded/:id
        public async Task<List<string>> GetOnboardedByVesselIdAsync(string vesselId)
        {
            string url = $"{BaseUrl}/onboarded/{vesselId}";
            var json = await GetAsync(url);
            return JsonConvert.DeserializeObject<List<string>>(json);
        }
    }
}
