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

        [JsonProperty("direction")]
        public int Direction { get; set; }

        [JsonProperty("picture")]
        public string Picture { get; set; }

        [JsonProperty("vessel_id")]
        public string VesselId { get; set; }

        [JsonProperty("action")]
        public int Action { get; set; }

        [JsonProperty("manual")]
        public bool Manual { get; set; } // Boolean value, non-nullable

        [JsonProperty("justification")]
        public string Justification { get; set; }

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
