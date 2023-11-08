using DockCheckWindows.Models;
using DockCheckWindows.Services;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace DockCheckWindows.Repositories
{
    public class CompanyRepository : BaseRepository<Company>
    {
        private const string BaseUrl = "http://localhost:3000/api/v1/companies";

        public CompanyRepository(ApiService apiService)
            : base(apiService)
        {
        }

        public async Task<Company> GetCompanyByIdAsync(string id)
        {
            var json = await GetAsync($"{BaseUrl}/{id}");
            return JsonConvert.DeserializeObject<Company>(json);
        }

        public async Task<string> GetAllCompaniesAsync()
        {
            return await GetAsync(BaseUrl);
        }

        public async Task<Company> CreateCompanyAsync(Company company)
        {
            var json = JsonConvert.SerializeObject(company);
            var response = await PostAsync($"{BaseUrl}/create", json, "Company");
            return JsonConvert.DeserializeObject<Company>(response);
        }
    }
}
