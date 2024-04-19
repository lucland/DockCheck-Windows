using Newtonsoft.Json;

namespace DockCheckWindows.Models
{
    public class Beacon
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("itag")]
        public string Itag { get; set; }

        [JsonProperty("is_valid")]
        public bool IsValid { get; set; }

        [JsonProperty("employee_id")] // Assuming employeeId in Dart translates to employee_id in C#
        public string EmployeeId { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        // Constructor
        public Beacon(string id, string itag, bool isValid, string employeeId, string status)
        {
            Id = id;
            Itag = itag;
            IsValid = isValid;
            EmployeeId = employeeId;
            Status = status;
        }

        // Default constructor for JSON deserialization
        public Beacon() { }

        // Method to deserialize JSON string to Beacon object
        public static Beacon FromJson(string jsonData)
        {
            return JsonConvert.DeserializeObject<Beacon>(jsonData);
        }

        // Method to serialize Beacon object to JSON string
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        // Method to create a new Beacon object with updated properties
        public Beacon CopyWith(string id = null, string itag = null, bool? isValid = null, string employeeId = null, string status = null)
        {
            return new Beacon(
                id ?? Id,
                itag ?? Itag,
                isValid ?? IsValid,
                employeeId ?? EmployeeId,
                status ?? Status
            );
        }
    }
}
