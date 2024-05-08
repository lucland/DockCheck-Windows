using Newtonsoft.Json;
using System;

namespace DockCheckWindows.Models
{
    public class Daily
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("employee_id")]
        public string EmployeeId { get; set; }

        [JsonProperty("first")]
        public DateTime First { get; set; }

        [JsonProperty("project_id")]
        public string ProjectId { get; set; }

        [JsonProperty("final")]
        public DateTime Final { get; set; }

        [JsonProperty("company")]
        public string Company { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("beacon_id")]
        public string BeaconId { get; set; }

        // Constructor
        public Daily(string id, string employeeId, DateTime first, string projectId, DateTime final, string company, string status, string beaconId)
        {
            Id = id;
            EmployeeId = employeeId;
            First = first;
            ProjectId = projectId;
            Final = final;
            Company = company;
            Status = status;
            BeaconId = beaconId;
        }

        // Default constructor for JSON deserialization
        public Daily() { }

        // Method to deserialize JSON string to Daily object
        public static Daily FromJson(string jsonData)
        {
            return JsonConvert.DeserializeObject<Daily>(jsonData);
        }

        // Method to serialize Daily object to JSON string
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        // Method to create a new Daily object with updated properties
        public Daily CopyWith(string id = null, string employeeId = null, DateTime? first = null, string projectId = null, DateTime? final = null, string company = null, string status = null, string beaconId = null)
        {
            return new Daily(
                id ?? Id,
                employeeId ?? EmployeeId,
                first ?? First,
                projectId ?? ProjectId,
                final ?? Final,
                company ?? Company,
                status ?? Status,
                beaconId ?? BeaconId
            );
        }
    }
}
