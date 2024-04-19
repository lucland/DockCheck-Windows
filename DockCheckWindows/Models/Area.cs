using Newtonsoft.Json;

namespace DockCheckWindows.Models
{
    public class Area
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("is_portalo")] // Assuming isPortalo in Dart translates to is_portalo in C#
        public bool IsPortalo { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        // Constructor
        public Area(string id, int count, string name, bool isPortalo, string status)
        {
            Id = id;
            Count = count;
            Name = name;
            IsPortalo = isPortalo;
            Status = status;
        }

        // Default constructor for JSON deserialization
        public Area() { }

        // Method to deserialize JSON string to Area object
        public static Area FromJson(string jsonData)
        {
            return JsonConvert.DeserializeObject<Area>(jsonData);
        }

        // Method to serialize Area object to JSON string
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        // Method to create a new Area object with updated properties
        public Area CopyWith(string id = null, int? count = null, string name = null, bool? isPortalo = null, string status = null)
        {
            return new Area(
                id ?? Id,
                count ?? Count,
                name ?? Name,
                isPortalo ?? IsPortalo,
                status ?? Status
            );
        }
    }
}
