using Newtonsoft.Json;
using System;

namespace DockCheckWindows.Models
{
    public class Pic
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("user_id")]
        public string UserId { get; set; }

        [JsonProperty("picture")]
        public string Picture { get; set; }

        public static Pic FromJson(string jsonData)
        {
            return JsonConvert.DeserializeObject<Pic>(jsonData);
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
