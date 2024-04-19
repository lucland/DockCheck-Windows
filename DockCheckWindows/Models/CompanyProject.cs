using Newtonsoft.Json;

namespace DockCheckWindows.Models
{
    public class CompanyProject
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("company_id")]
        public string CompanyId { get; set; }

        [JsonProperty("project_id")]
        public string ProjectId { get; set; }

        // Constructor
        public CompanyProject(string id, string companyId, string projectId)
        {
            Id = id;
            CompanyId = companyId;
            ProjectId = projectId;
        }

        // Default constructor for JSON deserialization
        public CompanyProject() { }

        // Method to deserialize JSON string to CompanyProject object
        public static CompanyProject FromJson(string jsonData)
        {
            return JsonConvert.DeserializeObject<CompanyProject>(jsonData);
        }

        // Method to serialize CompanyProject object to JSON string
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        // Method to create a new CompanyProject object with updated properties
        public CompanyProject CopyWith(string id = null, string companyId = null, string projectId = null)
        {
            return new CompanyProject(
                id ?? Id,
                companyId ?? CompanyId,
                projectId ?? ProjectId
            );
        }
    }
}
