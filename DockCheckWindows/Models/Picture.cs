using Newtonsoft.Json;

namespace DockCheckWindows.Models
{
    public class Picture
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("employee_id")]
        public string EmployeeId { get; set; }

        [JsonProperty("base_64")]
        public string Base64 { get; set; }

        [JsonProperty("doc_path")]
        public string DocPath { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        // Constructor
        public Picture(string id, string employeeId, string base64, string docPath, string status)
        {
            Id = id;
            EmployeeId = employeeId;
            Base64 = base64;
            DocPath = docPath;
            Status = status;
        }

        // Default constructor for JSON deserialization
        public Picture() { }

        // Method to deserialize JSON string to Picture object
        public static Picture FromJson(string jsonData)
        {
            return JsonConvert.DeserializeObject<Picture>(jsonData);
        }

        // Method to serialize Picture object to JSON string
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        // Method to create a new Picture object with updated properties
        public Picture CopyWith(string id = null, string employeeId = null, string base64 = null, string docPath = null, string status = null)
        {
            return new Picture(
                id ?? Id,
                employeeId ?? EmployeeId,
                base64 ?? Base64,
                docPath ?? DocPath,
                status ?? Status
            );
        }
    }
}
