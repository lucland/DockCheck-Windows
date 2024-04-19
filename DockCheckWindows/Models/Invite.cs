using Newtonsoft.Json;
using System;

namespace DockCheckWindows.Models
{
    public class Invite
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("accepted")]
        public bool Accepted { get; set; }

        [JsonProperty("sent")]
        public bool Sent { get; set; }

        [JsonProperty("thirdCompanyName")]
        public string ThirdCompanyName { get; set; }

        [JsonProperty("dateSent")]
        public DateTime DateSent { get; set; }

        [JsonProperty("viewed")]
        public bool Viewed { get; set; }

        [JsonProperty("project_id")]
        public string ProjectId { get; set; }

        // Constructor
        public Invite(string id, string email, bool accepted, bool sent, string thirdCompanyName, DateTime dateSent, bool viewed, string projectId)
        {
            Id = id;
            Email = email;
            Accepted = accepted;
            Sent = sent;
            ThirdCompanyName = thirdCompanyName;
            DateSent = dateSent;
            Viewed = viewed;
            ProjectId = projectId;
        }

        // Default constructor for JSON deserialization
        public Invite() { }

        // Method to deserialize JSON string to Invite object
        public static Invite FromJson(string jsonData)
        {
            return JsonConvert.DeserializeObject<Invite>(jsonData);
        }

        // Method to serialize Invite object to JSON string
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        // Method to create a new Invite object with updated properties
        public Invite CopyWith(string id = null, string email = null, bool? accepted = null, bool? sent = null, string thirdCompanyName = null, DateTime? dateSent = null, bool? viewed = null, string projectId = null)
        {
            return new Invite(
                id ?? Id,
                email ?? Email,
                accepted ?? Accepted,
                sent ?? Sent,
                thirdCompanyName ?? ThirdCompanyName,
                dateSent ?? DateSent,
                viewed ?? Viewed,
                projectId ?? ProjectId
            );
        }
    }
}
