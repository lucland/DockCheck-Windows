using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DockCheckWindows.Models
{
    public class Employee
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("authorizations_id")]
        public List<string> AuthorizationsId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("third_company_id")]
        public string ThirdCompanyId { get; set; }

        [JsonProperty("visitor_company")]
        public string VisitorCompany { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }

        [JsonProperty("number")]
        public int Number { get; set; }

        [JsonProperty("blood_type")]
        public string BloodType { get; set; }

        [JsonProperty("cpf")]
        public string Cpf { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("area")]
        public string Area { get; set; }

        [JsonProperty("last_area_found")]
        public string LastAreaFound { get; set; }

        [JsonProperty("last_time_found")]
        public DateTime LastTimeFound { get; set; }

        [JsonProperty("is_blocked")]
        public bool IsBlocked { get; set; }

        [JsonProperty("documents_ok")]
        public bool DocumentsOk { get; set; }

        [JsonProperty("block_reason")]
        public string BlockReason { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("user_id")]
        public string UserId { get; set; }

        [JsonProperty("telephone")]
        public string Telephone { get; set; }

        // Constructor
        public Employee(string id, List<string> authorizationsId, string name, string thirdCompanyId, string visitorCompany, string role, int number, string bloodType, string cpf, string email, string area, string lastAreaFound, DateTime lastTimeFound, bool isBlocked, bool documentsOk, string blockReason, string status, DateTime createdAt, DateTime updatedAt, string userId, string telephone)
        {
            Id = id;
            AuthorizationsId = authorizationsId;
            Name = name;
            ThirdCompanyId = thirdCompanyId;
            VisitorCompany = visitorCompany;
            Role = role;
            Number = number;
            BloodType = bloodType;
            Cpf = cpf;
            Email = email;
            Area = area;
            LastAreaFound = lastAreaFound;
            LastTimeFound = lastTimeFound;
            IsBlocked = isBlocked;
            DocumentsOk = documentsOk;
            BlockReason = blockReason;
            Status = status;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            UserId = userId;
            Telephone = telephone;
        }

        // Default constructor for JSON deserialization
        public Employee() { }

        // Method to deserialize JSON string to Employee object
        public static User FromJson(string jsonData)
        {
            return JsonConvert.DeserializeObject<User>(jsonData);
        }

        // Method to serialize Employee object to JSON string
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        // Method to create a new Employee object with updated properties
        public Employee CopyWith(string id = null, List<string> authorizationsId = null, string name = null, string thirdCompanyId = null, string visitorCompany = null, string role = null, int? number = null, string bloodType = null, string cpf = null, string email = null, string area = null, string lastAreaFound = null, DateTime? lastTimeFound = null, bool? isBlocked = null, bool? documentsOk = null, string blockReason = null, string status = null, DateTime? createdAt = null, DateTime? updatedAt = null, string userId = null, string telephone = null)
        {
            return new Employee(
                id ?? Id,
                authorizationsId ?? AuthorizationsId,
                name ?? Name,
                thirdCompanyId ?? ThirdCompanyId,
                visitorCompany ?? VisitorCompany,
                role ?? Role,
                number ?? Number,
                bloodType ?? BloodType,
                cpf ?? Cpf,
                email ?? Email,
                area ?? Area,
                lastAreaFound ?? LastAreaFound,
                lastTimeFound ?? LastTimeFound,
                isBlocked ?? IsBlocked,
                documentsOk ?? DocumentsOk,
                blockReason ?? BlockReason,
                status ?? Status,
                createdAt ?? CreatedAt,
                updatedAt ?? UpdatedAt,
                userId ?? UserId,
                telephone ?? Telephone
            );
        }
    }
}
