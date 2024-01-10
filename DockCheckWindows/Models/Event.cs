using Newtonsoft.Json;
using System;

namespace DockCheckWindows.Models
{
    public class Event
    {
        [JsonProperty("id")]
        public string Id { get; set; } // As the primary key, it's non-nullable

        [JsonProperty("portal_id")]
        public string PortalId { get; set; }

        [JsonProperty("user_id")]
        public string UserId { get; set; }

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; } // Assuming this is required and should not be nullable

        [JsonProperty("vessel_id")]
        public string VesselId { get; set; }

        [JsonProperty("action")]
        public int Action { get; set; }

        [JsonProperty("justification")]
        public string Justification { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("beacon_id")]
        public string BeaconId { get; set; }

        public static Event FromJson(string jsonData)
        {
            return JsonConvert.DeserializeObject<Event>(jsonData);
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

}
