using Newtonsoft.Json;
using System;

namespace DockCheckWindows.Models
{
    public class Beacon
    {
        [JsonProperty("itag")]
        public string Itag { get; set; }

        [JsonProperty("is_valid")]
        public bool IsValid { get; set; }

        [JsonProperty("user_id")]
        public string UserId { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

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