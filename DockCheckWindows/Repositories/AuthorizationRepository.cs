using DockCheckWindows.Models;
using DockCheckWindows.Services;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DockCheckWindows.Repositories
{
    public class AuthorizationRepository : BaseRepository<Authorization>
    {
        private const string BaseUrl = "http://localhost:3000/api/v1/authorizations";
        //liteDbService is a local database service
        private LiteDbService _liteDbService { get; set; }

        public AuthorizationRepository(ApiService apiService)
            : base(apiService)
        {
        }

        public async Task<Authorization> GetAuthorizationByIdAsync(string id)
        {
            var json = await GetAsync($"{BaseUrl}/{id}");
            return JsonConvert.DeserializeObject<Authorization>(json);
        }

        public async Task<IEnumerable<Authorization>> GetAuthorizationsByUserIdAsync(string userId)
        {
            var json = await GetAsync($"{BaseUrl}/{userId}");
            return JsonConvert.DeserializeObject<IEnumerable<Authorization>>(json);
        }

        public async Task<Authorization> CreateAuthorizationAsync(Authorization authorization)
        {
            var json = JsonConvert.SerializeObject(authorization);
            var response = await PostAsync(BaseUrl, json, "Authorization");
            return JsonConvert.DeserializeObject<Authorization>(response);
        }
    }
}
