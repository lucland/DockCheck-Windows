using DockCheckWindows.Models;
using DockCheckWindows.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Google.Rpc.Context.AttributeContext.Types;

namespace DockCheckWindows.Repositories
{
    public class VesselRepository : BaseRepository<Vessel>
    {
        private const string BaseUrl = "http://localhost:3000/api/v1/vessel";

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

        public async Task<string> GetVesselIdByNameAsync(string vesselName)
        {
            Console.WriteLine("GET ALL VESSELS");
            var vesselsJson = await GetAllVesselsAsync();
            var vessels = JsonConvert.DeserializeObject<List<Vessel>>(vesselsJson);
            var vessel = vessels.FirstOrDefault(v => v.Name.Equals(vesselName, StringComparison.OrdinalIgnoreCase));
            return vessel == null ? "vessel1" : vessel?.Id;
        }
    }
}
