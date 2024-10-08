﻿using Newtonsoft.Json;

namespace DockCheckWindows.Models
{
    public class Company
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("logo")]
        public string Logo { get; set; }

        [JsonProperty("razao_social")] // Assuming razaoSocial in Dart translates to razao_social in C#
        public string RazaoSocial { get; set; }

        [JsonProperty("cnpj")]
        public string Cnpj { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("telephone")]
        public string Telephone { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        // Constructor
        public Company(string id, string name, string logo, string razaoSocial, string cnpj, string address, string telephone, string email, string status)
        {
            Id = id;
            Name = name;
            Logo = logo;
            RazaoSocial = razaoSocial;
            Cnpj = cnpj;
            Address = address;
            Telephone = telephone;
            Email = email;
            Status = status;
        }

        // Default constructor for JSON deserialization
        public Company() { }

        // Method to deserialize JSON string to Company object
        public static Company FromJson(string jsonData)
        {
            return JsonConvert.DeserializeObject<Company>(jsonData);
        }

        // Method to serialize Company object to JSON string
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        // Method to create a new Company object with updated properties
        public Company CopyWith(string id = null, string name = null, string logo = null, string razaoSocial = null, string cnpj = null, string address = null, string telephone = null, string email = null, string status = null)
        {
            return new Company(
                id ?? Id,
                name ?? Name,
                logo ?? Logo,
                razaoSocial ?? RazaoSocial,
                cnpj ?? Cnpj,
                address ?? Address,
                telephone ?? Telephone,
                email ?? Email,
                status ?? Status
            );
        }
    }
}
