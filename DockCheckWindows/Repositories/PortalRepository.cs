using DockCheckWindows.Models;
using DockCheckWindows.Services;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace DockCheckWindows.Repositories
{
    public class PortalRepository : BaseRepository<Portal>
    {
        // private const string BaseUrl = "http://localhost:3000/api/v1/portals";
        private string BaseUrl = GlobalConfig.BaseApiUrl + "/portals";

        public PortalRepository(ApiService apiService)
            : base(apiService)
        {
        }

        public async Task<Portal> GetPortalByIdAsync(string id)
        {
            var json = await GetAsync($"{BaseUrl}/{id}");
            return JsonConvert.DeserializeObject<Portal>(json);
        }

        public async Task<string> GetAllPortalsAsync()
        {
            return await GetAsync(BaseUrl);
        }

        public async Task<Portal> CreatePortalAsync(Portal portal)
        {
            var json = JsonConvert.SerializeObject(portal);
            var response = await PostAsync($"{BaseUrl}/create", json, "Portal");
            return JsonConvert.DeserializeObject<Portal>(response);
        }

        // Additional methods for updating, deleting, etc., can be added here.
    }
}
