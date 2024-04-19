using Newtonsoft.Json;
using System;

namespace DockCheckWindows.Models
{
    public class Login
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("user_id")]
        public string UserId { get; set; }

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("expiration")]
        public DateTime Expiration { get; set; }

        [JsonProperty("system")]
        public string System { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        // Constructor
        public Login(string id, string userId, DateTime timestamp, DateTime expiration, string system, DateTime createdAt, DateTime updatedAt, string status)
        {
            Id = id;
            UserId = userId;
            Timestamp = timestamp;
            Expiration = expiration;
            System = system;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            Status = status;
        }

        // Default constructor for JSON deserialization
        public Login() { }

        // Method to deserialize JSON string to Login object
        public static Login FromJson(string jsonData)
        {
            return JsonConvert.DeserializeObject<Login>(jsonData);
        }

        // Method to serialize Login object to JSON string
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        // Method to create a new Login object with updated properties
        public Login CopyWith(string id = null, string userId = null, DateTime? timestamp = null, DateTime? expiration = null, string system = null, DateTime? createdAt = null, DateTime? updatedAt = null, string status = null)
        {
            return new Login(
                id ?? Id,
                userId ?? UserId,
                timestamp ?? Timestamp,
                expiration ?? Expiration,
                system ?? System,
                createdAt ?? CreatedAt,
                updatedAt ?? UpdatedAt,
                status ?? Status
            );
        }
    }
}
