using Newtonsoft.Json;
using System;

namespace DockCheckWindows.Models
{
    public class Document
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("expiration_date")]
        public DateTime ExpirationDate { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("employee_id")]
        public string EmployeeId { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        // Constructor
        public Document(string id, string type, DateTime expirationDate, string path, string employeeId, string status)
        {
            Id = id;
            Type = type;
            ExpirationDate = expirationDate;
            Path = path;
            EmployeeId = employeeId;
            Status = status;
        }

        // Default constructor for JSON deserialization
        public Document() { }

        // Method to deserialize JSON string to Document object
        public static Document FromJson(string jsonData)
        {
            return JsonConvert.DeserializeObject<Document>(jsonData);
        }

        // Method to serialize Document object to JSON string
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        // Method to create a new Document object with updated properties
        public Document CopyWith(string id = null, string type = null, DateTime? expirationDate = null, string path = null, string employeeId = null, string status = null)
        {
            return new Document(
                id ?? Id,
                type ?? Type,
                expirationDate ?? ExpirationDate,
                path ?? Path,
                employeeId ?? EmployeeId,
                status ?? Status
            );
        }
    }
}
