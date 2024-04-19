using Newtonsoft.Json;

namespace DockCheckWindows.Models
{
    public class ThirdCompanyAdmin
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("third_company_id")]
        public string ThirdCompanyId { get; set; }

        [JsonProperty("user_id")]
        public string UserId { get; set; }

        // Constructor
        public ThirdCompanyAdmin(string id, string thirdCompanyId, string userId)
        {
            Id = id;
            ThirdCompanyId = thirdCompanyId;
            UserId = userId;
        }

        // Default constructor for JSON deserialization
        public ThirdCompanyAdmin() { }

        // Method to deserialize JSON string to ThirdCompanyAdmin object
        public static ThirdCompanyAdmin FromJson(string jsonData)
        {
            return JsonConvert.DeserializeObject<ThirdCompanyAdmin>(jsonData);
        }

        // Method to serialize ThirdCompanyAdmin object to JSON string
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        // Method to create a new ThirdCompanyAdmin object with updated properties
        public ThirdCompanyAdmin CopyWith(string id = null, string thirdCompanyId = null, string userId = null)
        {
            return new ThirdCompanyAdmin(
                id ?? Id,
                thirdCompanyId ?? ThirdCompanyId,
                userId ?? UserId
            );
        }
    }
}
