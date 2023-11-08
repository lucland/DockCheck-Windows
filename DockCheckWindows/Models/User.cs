using Google.Cloud.Firestore;
using Newtonsoft.Json;
using System;

namespace DockCheckWindows
{

    public class User
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("authorizations_id")]
        public Guid[] AuthorizationsId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("company")]
        public string Company { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }

        [JsonProperty("project")]
        public string Project { get; set; }

        [JsonProperty("number")]
        public int Number { get; set; }

        [JsonProperty("identidade")]
        public string Identidade { get; set; }

        [JsonProperty("cpf")]
        public string CPF { get; set; }

        [JsonProperty("aso")]
        public DateTime ASO { get; set; }

        [JsonProperty("aso_document")]
        public string ASODocument { get; set; }

        [JsonProperty("has_aso")]
        public bool HasASO { get; set; }

        [JsonProperty("nr34")]
        public DateTime NR34 { get; set; }

        [JsonProperty("nr34_document")]
        public string NR34Document { get; set; }

        [JsonProperty("has_nr34")]
        public bool HasNR34 { get; set; }

        [JsonProperty("nr35")]
        public DateTime NR35 { get; set; }

        [JsonProperty("nr35_document")]
        public string NR35Document { get; set; }

        [JsonProperty("has_nr35")]
        public bool HasNR35 { get; set; }

        [JsonProperty("nr33")]
        public DateTime NR33 { get; set; }

        [JsonProperty("nr33_document")]
        public string NR33Document { get; set; }

        [JsonProperty("has_nr33")]
        public bool HasNR33 { get; set; }

        [JsonProperty("nr10")]
        public DateTime NR10 { get; set; }

        [JsonProperty("nr10_document")]
        public string NR10Document { get; set; }

        [JsonProperty("has_nr10")]
        public bool HasNR10 { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("area")]
        public string Area { get; set; }

        [JsonProperty("is_admin")]
        public bool IsAdmin { get; set; }

        [JsonProperty("is_visitor")]
        public bool IsVisitor { get; set; }

        [JsonProperty("is_guardian")]
        public bool IsGuardian { get; set; }

        [JsonProperty("is_blocked")]
        public bool IsBlocked { get; set; }

        [JsonProperty("block_reason")]
        public string BlockReason { get; set; }

        [JsonProperty("rfid")]
        public string RFID { get; set; }

        [JsonProperty("picture")]
        public string Picture { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("events")]
        public string[] Events { get; set; }

        [JsonProperty("type_job")]
        public string TypeJob { get; set; }

        [JsonProperty("start_job")]
        public DateTime StartJob { get; set; }

        [JsonProperty("end_job")]
        public DateTime EndJob { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("salt")]
        public string Salt { get; set; }

        [JsonProperty("hash")]
        public string Hash { get; set; }

        public static User FromJson(string jsonData)
        {
            return JsonConvert.DeserializeObject<User>(jsonData);
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public string ToString(DateTime date)
        {
            if (date == null)
            {
                return "";
            }
            else
            {
                return date.ToString("dd/MM/yyyy");
            }
        }
    }
}