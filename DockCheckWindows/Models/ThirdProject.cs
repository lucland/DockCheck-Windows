using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DockCheckWindows.Models
{
    public class ThirdProject
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("date_start")]
        public DateTime DateStart { get; set; }

        [JsonProperty("date_end")]
        public DateTime DateEnd { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("third_company_id")]
        public string ThirdCompanyId { get; set; }

        [JsonProperty("project_id")]
        public string ProjectId { get; set; }

        [JsonProperty("allowed_areas_id")]
        public List<string> AllowedAreasId { get; set; }

        [JsonProperty("employees_id")]
        public List<string> EmployeesId { get; set; }

        [JsonProperty("is_docking")]
        public bool IsDocking { get; set; }

        // Constructor
        public ThirdProject(string id, string name, DateTime dateStart, DateTime dateEnd, DateTime updatedAt, string status, string thirdCompanyId, string projectId, List<string> allowedAreasId, List<string> employeesId, bool isDocking)
        {
            Id = id;
            Name = name;
            DateStart = dateStart;
            DateEnd = dateEnd;
            UpdatedAt = updatedAt;
            Status = status;
            ThirdCompanyId = thirdCompanyId;
            ProjectId = projectId;
            AllowedAreasId = allowedAreasId;
            EmployeesId = employeesId;
            IsDocking = isDocking;
        }

        // Default constructor for JSON deserialization
        public ThirdProject() { }

        // Method to deserialize JSON string to ThirdProject object
        public static ThirdProject FromJson(string jsonData)
        {
            return JsonConvert.DeserializeObject<ThirdProject>(jsonData);
        }

        // Method to serialize ThirdProject object to JSON string
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        // Method to create a new ThirdProject object with updated properties
        public ThirdProject CopyWith(string id = null, string name = null, DateTime? dateStart = null, DateTime? dateEnd = null, DateTime? updatedAt = null, string status = null, string thirdCompanyId = null, string projectId = null, List<string> allowedAreasId = null, List<string> employeesId = null, bool? isDocking = null)
        {
            return new ThirdProject(
                id ?? Id,
                name ?? Name,
                dateStart ?? DateStart,
                dateEnd ?? DateEnd,
                updatedAt ?? UpdatedAt,
                status ?? Status,
                thirdCompanyId ?? ThirdCompanyId,
                projectId ?? ProjectId,
                allowedAreasId ?? AllowedAreasId,
                employeesId ?? EmployeesId,
                isDocking ?? IsDocking
            );
        }
    }
}
