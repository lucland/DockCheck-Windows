using Newtonsoft.Json;
using System;

namespace DockCheckWindows.Models
{
    public class Authorization
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("third_project_id")] // Assuming thirdProjectId in Dart translates to third_project_id in C#
        public string ThirdProjectId { get; set; }

        [JsonProperty("expiration_date")]
        public DateTime ExpirationDate { get; set; } // Note: Dart's DateTime.parse is not needed here in C#

        [JsonProperty("employee_id")] // Assuming employeeId in Dart translates to employee_id in C#
        public string EmployeeId { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        // Constructor
        public Authorization(string id, string thirdProjectId, DateTime expirationDate, string employeeId, string status)
        {
            Id = id;
            ThirdProjectId = thirdProjectId;
            ExpirationDate = expirationDate;
            EmployeeId = employeeId;
            Status = status;
        }

        // Default constructor for JSON deserialization
        public Authorization() { }

        // Method to deserialize JSON string to Authorization object
        public static Authorization FromJson(string jsonData)
        {
            return JsonConvert.DeserializeObject<Authorization>(jsonData);
        }

        // Method to serialize Authorization object to JSON string
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        // Method to create a new Authorization object with updated properties
        public Authorization CopyWith(string id = null, string thirdProjectId = null, DateTime? expirationDate = null, string employeeId = null, string status = null)
        {
            return new Authorization(
                id ?? Id,
                thirdProjectId ?? ThirdProjectId,
                expirationDate ?? ExpirationDate,
                employeeId ?? EmployeeId,
                status ?? Status
            );
        }
    }
}
