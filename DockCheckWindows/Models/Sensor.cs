using System.Collections.Generic;
using Newtonsoft.Json;

namespace DockCheckWindows.Models
{
    public class Sensor
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("beacons_found")]
        public List<string> BeaconsFound { get; set; }

        [JsonProperty("area_id")]
        public string AreaId { get; set; }

        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("in_vessel")]
        public bool InVessel { get; set; }

        [JsonProperty("location_x")]
        public int LocationX { get; set; }

        [JsonProperty("location_y")]
        public int LocationY { get; set; }

        // Constructor
        public Sensor(
            string id,
            List<string> beaconsFound,
            string areaId,
            int code,
            string status,
            bool inVessel,
            int locationX,
            int locationY)
        {
            Id = id;
            BeaconsFound = beaconsFound;
            AreaId = areaId;
            Code = code;
            Status = status;
            InVessel = inVessel;
            LocationX = locationX;
            LocationY = locationY;
        }

        // Default constructor for JSON deserialization
        public Sensor() { }

        // Method to deserialize JSON string to Sensor object
        public static Sensor FromJson(string jsonData)
        {
            return JsonConvert.DeserializeObject<Sensor>(jsonData);
        }

        // Method to serialize Sensor object to JSON string
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        // Method to create a new Sensor object with updated properties
        public Sensor CopyWith(
            string id = null,
            List<string> beaconsFound = null,
            string areaId = null,
            int? code = null,
            string status = null,
            bool? inVessel = null,
            int? locationX = null,
            int? locationY = null)
        {
            return new Sensor(
                id ?? Id,
                beaconsFound ?? BeaconsFound,
                areaId ?? AreaId,
                code ?? Code,
                status ?? Status,
                inVessel ?? InVessel,
                locationX ?? LocationX,
                locationY ?? LocationY
            );
        }
    }
}
