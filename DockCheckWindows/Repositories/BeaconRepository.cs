using DockCheckWindows.Models;
using DockCheckWindows.Services;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace DockCheckWindows.Repositories
{
    public class BeaconRepository : BaseRepository<Beacon>
    {
        private const string BaseUrl = "http://localhost:3000/api/v1/beacons";

        public BeaconRepository(ApiService apiService)
            : base(apiService)
        {
        }

        public async Task<Beacon> GetBeaconByIdAsync(string id)
        {
            var json = await GetAsync($"{BaseUrl}/{id}");
            return JsonConvert.DeserializeObject<Beacon>(json);
        }

        public async Task<string> GetAllBeaconsAsync()
        {
            return await GetAsync(BaseUrl);
        }

        public async Task<Beacon> CreateBeaconAsync(Beacon beacon)
        {
            var json = JsonConvert.SerializeObject(beacon);
            var response = await PostAsync($"{BaseUrl}/create", json, "Beacon");
            return JsonConvert.DeserializeObject<Beacon>(response);
        }
    }
}
