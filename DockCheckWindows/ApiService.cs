using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace DockCheckWindows
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<string> GetDataAsync(string url)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                // Tratar erros aqui
                return null;
            }
        }

        public async Task<string> PostDataAsync(string url, string data)
        {
            HttpResponseMessage response = await _httpClient.PostAsync(url, new StringContent(data, Encoding.UTF8, "application/json"));
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                // Tratar erros aqui
                return null;
            }
        }

        public async Task<string> PutDataAsync(string url, string data)
        {
            HttpResponseMessage response = await _httpClient.PutAsync(url, new StringContent(data, Encoding.UTF8, "application/json"));
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                // Tratar erros aqui
                return null;
            }
        }

        public async Task<string> DeleteDataAsync(string url)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                // Tratar erros aqui
                return null;
            }
        }

    }
}
