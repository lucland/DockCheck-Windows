using Newtonsoft.Json;

namespace DockCheckWindows.Models
{
    public class CompanyAdmin
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("company_id")]
        public string CompanyId { get; set; }

        [JsonProperty("user_id")]
        public string UserId { get; set; }

        // Constructor
        public CompanyAdmin(string id, string companyId, string userId)
        {
            Id = id;
            CompanyId = companyId;
            UserId = userId;
        }

        // Default constructor for JSON deserialization
        public CompanyAdmin() { }

        // Method to deserialize JSON string to CompanyAdmin object
        public static CompanyAdmin FromJson(string jsonData)
        {
            return JsonConvert.DeserializeObject<CompanyAdmin>(jsonData);
        }

        // Method to serialize CompanyAdmin object to JSON string
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        // Method to create a new CompanyAdmin object with updated properties
        public CompanyAdmin CopyWith(string id = null, string companyId = null, string userId = null)
        {
            return new CompanyAdmin(
                id ?? Id,
                companyId ?? CompanyId,
                userId ?? UserId
            );
        }
    }
}
