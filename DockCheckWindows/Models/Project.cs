using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace DockCheckWindows.Models
{
    public class Project
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("date_start")]
        public DateTime DateStart { get; set; }

        [JsonProperty("date_end")]
        public DateTime DateEnd { get; set; }

        [JsonProperty("vessel_id")]
        public string VesselId { get; set; }

        [JsonProperty("company_id")]
        public string CompanyId { get; set; }

        [JsonProperty("third_companies_id")]
        public List<string> ThirdCompaniesId { get; set; }

        [JsonProperty("admins_id")]
        public List<string> AdminsId { get; set; }

        [JsonProperty("employees_id")]
        public List<string> EmployeesId { get; set; }

        [JsonProperty("areas_id")]
        public List<string> AreasId { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("is_docking")]
        public bool IsDocking { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("user_id")]
        public string UserId { get; set; }

        // Constructor
        public Project(
            string id,
            string name,
            DateTime dateStart,
            DateTime dateEnd,
            string vesselId,
            string companyId,
            List<string> thirdCompaniesId,
            List<string> adminsId,
            List<string> employeesId,
            List<string> areasId,
            string address,
            bool isDocking,
            string status,
            string userId)
        {
            Id = id;
            Name = name;
            DateStart = dateStart;
            DateEnd = dateEnd;
            VesselId = vesselId;
            CompanyId = companyId;
            ThirdCompaniesId = thirdCompaniesId;
            AdminsId = adminsId;
            EmployeesId = employeesId;
            AreasId = areasId;
            Address = address;
            IsDocking = isDocking;
            Status = status;
            UserId = userId;
        }

        // Default constructor for JSON deserialization
        public Project() { }

        // Method to deserialize JSON string to Project object
        public static Project FromJson(string jsonData)
        {
            return JsonConvert.DeserializeObject<Project>(jsonData);
        }

        // Method to serialize Project object to JSON string
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        // Method to create a new Project object with updated properties
        public Project CopyWith(
            string id = null,
            string name = null,
            DateTime? dateStart = null,
            DateTime? dateEnd = null,
            string vesselId = null,
            string companyId = null,
            List<string> thirdCompaniesId = null,
            List<string> adminsId = null,
            List<string> employeesId = null,
            List<string> areasId = null,
            string address = null,
            bool? isDocking = null,
            string status = null,
            string userId = null)
        {
            return new Project(
                id ?? Id,
                name ?? Name,
                dateStart ?? DateStart,
                dateEnd ?? DateEnd,
                vesselId ?? VesselId,
                companyId ?? CompanyId,
                thirdCompaniesId ?? ThirdCompaniesId,
                adminsId ?? AdminsId,
                employeesId ?? EmployeesId,
                areasId ?? AreasId,
                address ?? Address,
                isDocking ?? IsDocking,
                status ?? Status,
                userId ?? UserId
            );
        }
    }
}
