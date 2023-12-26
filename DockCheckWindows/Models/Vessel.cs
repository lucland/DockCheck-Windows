using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DockCheckWindows.Models
{
    public class Vessel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("company_id")]
        public string CompanyId { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; } // Assuming that the date is always provided and non-nullable

        [JsonProperty("id")]
        public string Id { get; set; } // Primary key, non-nullable

        [JsonProperty("admins")]
        public List<string> Admins { get; set; }

        [JsonProperty("onboarded_count")]
        public int OnboardedCount { get; set; }

        [JsonProperty("portals")]
        public List<string> Portals { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        public static Vessel FromJson(string jsonData)
        {
            return JsonConvert.DeserializeObject<Vessel>(jsonData);
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

}
