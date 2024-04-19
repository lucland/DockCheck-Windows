using Newtonsoft.Json;
using System;

namespace DockCheckWindows.Models
{
    public class Event
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("employee_id")]
        public string EmployeeId { get; set; }

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("project_id")]
        public string ProjectId { get; set; }

        [JsonProperty("action")]
        public int Action { get; set; }

        [JsonProperty("sensor_id")]
        public string SensorId { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("beacon_id")]
        public string BeaconId { get; set; }

        // Constructor
        public Event(string id, string employeeId, DateTime timestamp, string projectId, int action, string sensorId, string status, string beaconId)
        {
            Id = id;
            EmployeeId = employeeId;
            Timestamp = timestamp;
            ProjectId = projectId;
            Action = action;
            SensorId = sensorId;
            Status = status;
            BeaconId = beaconId;
        }

        // Default constructor for JSON deserialization
        public Event() { }

        // Method to deserialize JSON string to Event object
        public static Event FromJson(string jsonData)
        {
            return JsonConvert.DeserializeObject<Event>(jsonData);
        }

        // Method to serialize Event object to JSON string
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        // Method to create a new Event object with updated properties
        public Event CopyWith(string id = null, string employeeId = null, DateTime? timestamp = null, string projectId = null, int? action = null, string sensorId = null, string status = null, string beaconId = null)
        {
            return new Event(
                id ?? Id,
                employeeId ?? EmployeeId,
                timestamp ?? Timestamp,
                projectId ?? ProjectId,
                action ?? Action,
                sensorId ?? SensorId,
                status ?? Status,
                beaconId ?? BeaconId
            );
        }
    }
}
