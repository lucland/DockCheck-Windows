using DockCheckWindows.Models;
using DockCheckWindows.Services;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace DockCheckWindows.Repositories
{
    public class ReceptorRepository : BaseRepository<Receptor>
    {
        private string BaseUrl = GlobalConfig.BaseApiUrl + "/receptors";
        // private const string BaseUrl = "http://localhost:3000/api/v1/receptors";

        public ReceptorRepository(ApiService apiService)
            : base(apiService)
        {
        }

        public async Task<Receptor> GetReceptorByIdAsync(string id)
        {
            var json = await GetAsync($"{BaseUrl}/{id}");
            return JsonConvert.DeserializeObject<Receptor>(json);
        }

        public async Task<string> GetAllReceptorsAsync()
        {
            return await GetAsync(BaseUrl);
        }

        public async Task<Receptor> CreateReceptorAsync(Receptor receptor)
        {
            var json = JsonConvert.SerializeObject(receptor);
            var response = await PostAsync($"{BaseUrl}/create", json, "Receptor");
            return JsonConvert.DeserializeObject<Receptor>(response);
        }
    }
}
