using Newtonsoft.Json;
using System.Collections.Generic;

namespace DockCheckWindows.Models // You can replace "YourNamespace" with the appropriate namespace for your project
{
    public class Vessel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("company_id")]
        public string CompanyId { get; set; }

        [JsonProperty("crew_id")]
        public List<string> CrewId { get; set; }

        [JsonProperty("onboarded_count")]
        public int OnboardedCount { get; set; }

        [JsonProperty("areas_id")]
        public List<string> AreasId { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        // Constructor
        public Vessel(string id, string name, string companyId, List<string> crewId, int onboardedCount, List<string> areasId, string status)
        {
            Id = id;
            Name = name;
            CompanyId = companyId;
            CrewId = crewId;
            OnboardedCount = onboardedCount;
            AreasId = areasId;
            Status = status;
        }

        // Default constructor for JSON deserialization
        public Vessel() { }

        // Method to deserialize JSON string to Vessel object
        public static Vessel FromJson(string jsonData)
        {
            return JsonConvert.DeserializeObject<Vessel>(jsonData);
        }

        // Method to serialize Vessel object to JSON string
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        // Method to create a new Vessel object with updated properties
        public Vessel CopyWith(string id = null, string name = null, string companyId = null, List<string> crewId = null, int? onboardedCount = null, List<string> areasId = null, string status = null)
        {
            return new Vessel(
                id ?? Id,
                name ?? Name,
                companyId ?? CompanyId,
                crewId ?? CrewId,
                onboardedCount ?? OnboardedCount,
                areasId ?? AreasId,
                status ?? Status
            );
        }
    }
}
