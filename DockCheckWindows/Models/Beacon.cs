using Newtonsoft.Json;
using System;

namespace DockCheckWindows.Models
{
    public class Beacon
    {
        [JsonProperty("rssi")]
        public string RSSI { get; set; }

        [JsonProperty("found")]
        public DateTime found { get; set; }

        [JsonProperty("user_id")]
        public string UserId { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        public static Beacon FromJson(string jsonData)
        {
            return JsonConvert.DeserializeObject<Beacon>(jsonData);
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}