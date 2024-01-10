using Newtonsoft.Json;
using System;

namespace DockCheckWindows.Models
{
    public class Portal
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; } // Primary key, non-nullable

        [JsonProperty("vessel_id")]
        public string VesselId { get; set; }

        [JsonProperty("user_id")]
        public string UserId { get; set; }

        [JsonProperty("onboard_count")]
        public string OnboardCount { get; set; }

        [JsonProperty("last_event")]
        public DateTime LastEvent { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        public static Portal FromJson(string jsonData)
        {
            return JsonConvert.DeserializeObject<Portal>(jsonData);
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

}
