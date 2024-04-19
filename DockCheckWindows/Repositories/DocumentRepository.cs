using DockCheckWindows.Models;
using DockCheckWindows.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DockCheckWindows.Repositories
{
    public class DocumentRepository : BaseRepository<Document>
    {
        private string BaseUrl = GlobalConfig.BaseApiUrl + "/documents";

        public DocumentRepository(ApiService apiService)
            : base(apiService)
        {
        }

        public async Task<bool> CreateDocumentAsync(Document document)
        {
            Console.WriteLine("Creating document...");
            var json = JsonConvert.SerializeObject(document);
            var response = await PostAsync($"{BaseUrl}/create", json, "Document");
            return !string.IsNullOrEmpty(response);
        }

    }
}
