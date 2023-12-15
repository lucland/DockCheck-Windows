using Newtonsoft.Json;
using System;

namespace DockCheckWindows.Models
{
    public class Login
    {
        [JsonProperty("user_id")]
        public string UserId { get; set; } // Assuming non-nullable

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; } // Assuming this should not be nullable

        [JsonProperty("expiration")]
        public DateTime Expiration { get; set; } // Assuming this should not be nullable

        [JsonProperty("system")]
        public string System { get; set; } // Assuming non-nullable

        [JsonProperty("status")]
        public string Status { get; set; }

        public static Login FromJson(string jsonData)
        {
            return JsonConvert.DeserializeObject<Login>(jsonData);
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

}
