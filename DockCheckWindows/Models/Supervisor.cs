using Newtonsoft.Json;
using System;

namespace DockCheckWindows.Models
{
    public class Supervisor
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("salt")]
        public string Salt { get; set; } // This should probably not be exposed publicly

        [JsonProperty("hash")]
        public string Hash { get; set; } // This should probably not be exposed publicly

        [JsonProperty("company_id")]
        public string CompanyId { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; } // Primary key, non-nullable

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        public static Supervisor FromJson(string jsonData)
        {
            return JsonConvert.DeserializeObject<Supervisor>(jsonData);
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
    }

