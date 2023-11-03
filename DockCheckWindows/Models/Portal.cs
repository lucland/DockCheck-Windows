using Newtonsoft.Json;
using System;

namespace DockCheckWindows.Models
{
    public class Portal
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; } // Primary key, non-nullable

        [JsonProperty("vessel_id")]
        public string VesselId { get; set; }

        [JsonProperty("camera_status")]
        public int CameraStatus { get; set; }

        [JsonProperty("camera_ip")]
        public string CameraIp { get; set; }

        [JsonProperty("rfid_status")]
        public int RfidStatus { get; set; }

        [JsonProperty("rfid_ip")]
        public string RfidIp { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; } // Non-nullable, assuming this is always provided

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; } // Non-nullable, assuming this is always provided

        public static Portal FromJson(string jsonData)
        {
            return JsonConvert.DeserializeObject<Portal>(jsonData);
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

}
