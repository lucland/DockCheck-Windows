using DockCheckWindows.Models;
using DockCheckWindows.Services;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace DockCheckWindows.Repositories
{
    public class SupervisorRepository : BaseRepository<Supervisor>
    {
        // private const string BaseUrl = "http://localhost:3000/api/v1/supervisors";
        private string BaseUrl = GlobalConfig.BaseApiUrl + "/supervisors";

        public SupervisorRepository(ApiService apiService)
            : base(apiService)
        {
        }

        public async Task<Supervisor> GetSupervisorByIdAsync(string id)
        {
            var json = await GetAsync($"{BaseUrl}/{id}");
            return JsonConvert.DeserializeObject<Supervisor>(json);
        }

        public async Task<string> GetAllSupervisorsAsync()
        {
            return await GetAsync(BaseUrl);
        }

        public async Task<Supervisor> CreateSupervisorAsync(Supervisor supervisor)
        {
            var json = JsonConvert.SerializeObject(supervisor);
            var response = await PostAsync(BaseUrl, json, "Supervisor");
            return JsonConvert.DeserializeObject<Supervisor>(response);
        }

        // Additional methods for updating, deleting, etc., can be added here.
    }
}

