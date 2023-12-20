using DockCheckWindows.Models;
using DockCheckWindows.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Google.Rpc.Context.AttributeContext.Types;

namespace DockCheckWindows.Repositories
{
    public class PicRepository : BaseRepository<Pic>
    {
        private const string BaseUrl = "http://localhost:3000/api/v1/pictures";

        public PicRepository(ApiService apiService)
            : base(apiService)
        {
        }

        public async Task<Pic> AddPictureAsync(Pic picture)
        {
            var json = JsonConvert.SerializeObject(picture);
            var response = await PostAsync(BaseUrl, json, "Pic");
            return JsonConvert.DeserializeObject<Pic>(response);
        }

        // Get a picture by ID
        public async Task<Pic> GetPictureAsync(string id)
        {
            var json = await GetAsync($"{BaseUrl}/{id}");
            return JsonConvert.DeserializeObject<Pic>(json);
        }

        // Update a picture
        public async Task UpdatePictureAsync(Pic picture)
        {
            var json = JsonConvert.SerializeObject(picture);
            await PutAsync($"{BaseUrl}/{picture.Id}", json, "Pic");
        }
    }
}
