using Newtonsoft.Json;
using System;
using System.Security.Cryptography;
using System.Text;

namespace DockCheckWindows.Models
{
    public class Supervisor
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("salt")]
        public string Salt { get; private set; } // This should probably not be exposed publicly

        [JsonProperty("hash")]
        public string Hash { get; private set; } // This should probably not be exposed publicly

        [JsonProperty("company_id")]
        public string CompanyId { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; } // Primary key, non-nullable

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        // Constructor, other methods...

        public void SetPassword(string password)
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] saltBytes = new byte[16];
                rng.GetBytes(saltBytes);
                Salt = BitConverter.ToString(saltBytes).Replace("-", "").ToLower();
            }

            Hash = HashPassword(password, Salt);
        }

        public bool ValidPassword(string password)
        {
            string testHash = HashPassword(password, Salt);
            return Hash == testHash;
        }

        private static string HashPassword(string password, string salt)
        {
            byte[] saltBytes = Encoding.UTF8.GetBytes(salt);
            using (var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, saltBytes, 1000, HashAlgorithmName.SHA512))
            {
                return BitConverter.ToString(rfc2898DeriveBytes.GetBytes(64)).Replace("-", "").ToLower();
            }
        }

        public static Supervisor FromJson(string jsonData)
        {
            return JsonConvert.DeserializeObject<Supervisor>(jsonData);
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
    }

