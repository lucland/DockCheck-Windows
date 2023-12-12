using Newtonsoft.Json;
using System;

namespace DockCheckWindows.Models
{
    public class Receptor
    {
        [JsonProperty("vessel")]
        public string Vessel { get; set; }

        [JsonProperty("beacons")]
        public string[] Beacons { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        public static Receptor FromJson(string jsonData)
        {
            return JsonConvert.DeserializeObject<Receptor>(jsonData);
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
