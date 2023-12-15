using Newtonsoft.Json;
using System;

namespace DockCheckWindows.Models
{
    public class Company
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("logo")]
        public string Logo { get; set; }

        [JsonProperty("supervisors")]
        public string[] Supervisors { get; set; }

        [JsonProperty("vessels")]
        public string[] Vessels { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("expiration_date")]
        public DateTime ExpirationDate { get; set; }

        public static Company FromJson(string jsonData)
        {
            return JsonConvert.DeserializeObject<Company>(jsonData);
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
