using DockCheckWindows.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DockCheckWindows.Repositories
{
    public abstract class BaseRepository<T> where T : new()
    {
        private ApiService _apiService;

        protected BaseRepository(ApiService apiService)
        {
            _apiService = apiService ?? throw new ArgumentNullException(nameof(apiService));
        }

        protected async Task<string> GetAsync(string url)
        {
            try
            {
                Console.WriteLine($"GET {url}");
                return await _apiService.GetDataAsync(url);
            }
            catch
            {
                Console.WriteLine($"GET {url} failed. Fetching data from LiteDB.");
                // Use the singleton instance of LiteDbService
                return JsonConvert.SerializeObject(LiteDbService.Instance.GetAll<T>("User"));
            }
        }

        protected async Task<string> PostAsync(string url, string data, string collectionName)
        {
            try
            {
                var item = JsonConvert.DeserializeObject<T>(data);
                if (item == null) throw new InvalidOperationException("Deserialized item is null.");

                // Use the singleton instance of LiteDbService
                LiteDbService.Instance.Insert(item, collectionName);
                return await _apiService.PostDataAsync(url, data);
            }
            catch (Exception ex)
            {
                // Log the exception if necessary
                Console.WriteLine($"An error occurred: {ex.Message}");

                var item = JsonConvert.DeserializeObject<T>(data);
                if (item == null) throw new InvalidOperationException("Deserialized item is null.");

                // Use the singleton instance of LiteDbService
                LiteDbService.Instance.Insert(item, collectionName);
                return JsonConvert.SerializeObject(item);
            }
        }
    }
}
