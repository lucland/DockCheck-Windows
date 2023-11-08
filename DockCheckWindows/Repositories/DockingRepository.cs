using DockCheckWindows.Models;
using DockCheckWindows.Services;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace DockCheckWindows.Repositories
{
    public class DockingRepository : BaseRepository<Docking>
    {
        private const string BaseUrl = "http://localhost:3000/api/v1/dockings";

        public DockingRepository(ApiService apiService)
            : base(apiService)
        {
        }

        public async Task<Docking> GetDockingByIdAsync(string id)
        {
            var json = await GetAsync($"{BaseUrl}/{id}");
            return JsonConvert.DeserializeObject<Docking>(json);
        }

        public async Task<string> GetAllDockingsAsync()
        {
            return await GetAsync(BaseUrl);
        }

        public async Task<Docking> CreateDockingAsync(Docking docking)
        {
            var json = JsonConvert.SerializeObject(docking);
            var response = await PostAsync($"{BaseUrl}/create", json, "Docking");
            return JsonConvert.DeserializeObject<Docking>(response);
        }
    }
}