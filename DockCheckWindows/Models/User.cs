using Newtonsoft.Json;
using System;

namespace DockCheckWindows.Models // You can replace "YourNamespace" with the appropriate namespace for your project
{
    public class User
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("company_id")]
        public string CompanyId { get; set; }

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

        [JsonProperty("is_blocked")]
        public bool IsBlocked { get; set; }

        [JsonProperty("block_reason")]
        public string BlockReason { get; set; }

        [JsonProperty("can_create")]
        public bool CanCreate { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("salt")]
        public string Salt { get; set; }

        [JsonProperty("hash")]
        public string Hash { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        // Constructor
        public User(string id, string name, string companyId, string role, int number, string bloodType, string cpf, string email, bool isBlocked, string blockReason, bool canCreate, string username, string salt, string hash, string status)
        {
            Id = id;
            Name = name;
            CompanyId = companyId;
            Role = role;
            Number = number;
            BloodType = bloodType;
            Cpf = cpf;
            Email = email;
            IsBlocked = isBlocked;
            BlockReason = blockReason;
            CanCreate = canCreate;
            Username = username;
            Salt = salt;
            Hash = hash;
            Status = status;
        }

        // Default constructor for JSON deserialization
        public User() { }

        // Method to deserialize JSON string to User object
        public static User FromJson(string jsonData)
        {
            return JsonConvert.DeserializeObject<User>(jsonData);
        }

        // Method to serialize User object to JSON string
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        // Method to create a new User object with updated properties
        public User CopyWith(string id = null, string name = null, string companyId = null, string role = null, int? number = null, string bloodType = null, string cpf = null, string email = null, bool? isBlocked = null, string blockReason = null, bool? canCreate = null, string username = null, string salt = null, string hash = null, string status = null)
        {
            return new User(
                (string)(id ?? this.Id),
                (string)(name ?? this.Name),
                companyId ?? CompanyId,
                (string)(role ?? this.Role),
                (int)(number ?? this.Number),
                (string)(bloodType ?? this.BloodType),
                (string)(cpf ?? this.Cpf),
                (string)(email ?? this.Email),
                (bool)(isBlocked ?? this.IsBlocked),
                (string)(blockReason ?? this.BlockReason),
                canCreate ?? CanCreate,
                username ?? Username,
                salt ?? Salt,
                hash ?? Hash,
                (string)(status ?? this.Status)
            );
        }
    }
}
