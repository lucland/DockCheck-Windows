using Newtonsoft.Json;
using System;

namespace DockCheckWindows.Models
{
    public class Docking
    {
        [JsonProperty("onboarded_count")]
        public int OnboardedCount { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; } // As primary key, it's non-nullable

        [JsonProperty("date_start")]
        public DateTime DateStart { get; set; } // Nullable DateTime if the date can be null

        [JsonProperty("date_end")]
        public DateTime DateEnd { get; set; } // Nullable DateTime if the date can be null

        [JsonProperty("admins")]
        public string[] Admins { get; set; } // Array of strings, which can be null by default

        [JsonProperty("vessel_id")]
        public string VesselId { get; set; } // Non-nullable unless the design allows nulls

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; } // Assuming this should not be nullable

        [JsonProperty("draft_meters")]
        public double DraftMeters { get; set; } // Double value, non-nullable

        public static Docking FromJson(string jsonData)
        {
            return JsonConvert.DeserializeObject<Docking>(jsonData);
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

}
