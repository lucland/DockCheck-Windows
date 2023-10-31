using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DockCheckWindows
{
    public class User
    {
        public User(
     string id = "-",
     List<string> authorizations_id = null,
     string name = "Unknown",
     string company = "Unknown",
     string role = "Unknown",
     string project = "N/A",
     string number = "N/A",
     string identidade = "-",
     string cpf = "-",
     DateTime aso = new DateTime(),
     string aso_document = "N/A",
     bool has_aso = false,
     DateTime nr34 = new DateTime(),
     string nr34_document = "N/A",
     bool has_nr34 = false,
     DateTime nr35 = new DateTime(),
     string nr35_document = "N/A",
     bool has_nr35 = false,
     DateTime nr33 = new DateTime(),
     string nr33_document = "N/A",
     bool has_nr33 = false,
     DateTime nr10 = new DateTime(),
     string nr10_document = "N/A",
     bool has_nr10 = false,
     string email = "N/A",
     string area = "N/A",
     bool is_admin = false,
     bool is_visitor = false,
     bool is_guardian = false,
     bool is_blocked = false,
     string blocked_reason = "N/A",
     string rfid = "N/A",
     string picture = "N/A",
     DateTime created_at = new DateTime(),
     DateTime updated_at = new DateTime(),
     List<string> events = null,
     string type_job = "N/A",
     DateTime start_job = new DateTime(),
     DateTime end_job = new DateTime(),
     string username = "N/A",
     string salt = "N/A",
     string hash = "N/A")
        {
            Id = id;
            Authorizations = authorizations_id;
            Name = name;
            Company = company;
            Role = role;
            Project = project;
            Number = number;
            Identidade = identidade;
            Cpf = cpf;
            Aso = aso;
            AsoDocument = aso_document;
            HasAso = has_aso;
            Nr34 = nr34;
            Nr34Document = nr34_document;
            HasNr34 = has_nr34;
            Nr35 = nr35;
            Nr35Document = nr35_document;
            HasNr35 = has_nr35;
            Nr33 = nr33;
            Nr33Document = nr33_document;
            HasNr33 = has_nr33;
            Nr10 = nr10;
            Nr10Document = nr10_document;
            HasNr10 = has_nr10;
            Email = email;
            Area = area;
            IsAdmin = is_admin;
            IsVisitor = is_visitor;
            IsGuardian = is_guardian;
            IsBlocked = is_blocked;
            BlockedReason = blocked_reason;
            Rfid = rfid;
            Picture = picture;
            CreatedAt = created_at;
            UpdatedAt = updated_at;
            Events = events;
            TypeJob = type_job;
            StartJob = start_job;
            EndJob = end_job;
            Username = username;
            Salt = salt;
            Hash = hash;
        }
        public string Id { get; set; }
        public List<string> Authorizations { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string Role { get; set; }
        public string Project { get; set; }
        public string Number { get; set; }
        public string Identidade { get; set; }
        public string Cpf { get; set; }
        public DateTime Aso { get; set; }
        public string AsoDocument { get; set; }
        public bool HasAso { get; set; }
        public DateTime Nr34 { get; set; }
        public string Nr34Document { get; set; }
        public bool HasNr34 { get; set; }
        public DateTime Nr35 { get; set; }
        public string Nr35Document { get; set; }
        public bool HasNr35 { get; set; }
        public DateTime Nr33 { get; set; }
        public string Nr33Document { get; set; }
        public bool HasNr33 { get; set; }
        public DateTime Nr10 { get; set; }
        public string Nr10Document { get; set; }
        public bool HasNr10 { get; set; }
        public string Email { get; set; }
        public string Area { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsVisitor { get; set; }
        public bool IsGuardian { get; set; }
        public bool IsBlocked { get; set; }
        public string BlockedReason { get; set; }
        public string Rfid { get; set; }
        public string Picture { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<string> Events { get; set; }
        public string TypeJob { get; set; }
        public DateTime StartJob { get; set; }
        public DateTime EndJob { get; set; }
        public string Username { get; set; }
        public string Salt { get; set; }
        public string Hash { get; set; }

        //from and to json methods
        public override string ToString()
        {
            return base.ToString();
        }

        public static User FromJson(string json)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<User>(json);
        }

        public static string ToJson(User user)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(user);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            var other = (User)obj;
            return Number == other.Number &&
            Name == other.Name &&
            Company == other.Company &&
                   Identidade == other.Identidade &&
                   Cpf == other.Cpf;
        }

        // Override GetHashCode as well, using the properties used in Equals method
        public override int GetHashCode()
        {
            return Id.GetHashCode() ^
                Name.GetHashCode() ^
                Company.GetHashCode() ^
                Identidade.GetHashCode() ^
                Cpf.GetHashCode();
        }
    }
}