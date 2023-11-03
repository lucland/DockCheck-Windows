using Newtonsoft.Json;
using System;

namespace DockCheckWindows.Models
{
    public class Authorization
    {
        [JsonProperty("id")]
        public Guid Id { get; set; } // Assuming that UUID translates to Guid in C#

        [JsonProperty("user_id")]
        public string UserId { get; set; }

        [JsonProperty("vessel_id")]
        public string VesselId { get; set; }

        [JsonProperty("expiration_date")]
        public DateTime? ExpirationDate { get; set; } // Nullable DateTime if the date can be null

        public static Authorization FromJson(string jsonData)
        {
            return JsonConvert.DeserializeObject<Authorization>(jsonData);
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

}
