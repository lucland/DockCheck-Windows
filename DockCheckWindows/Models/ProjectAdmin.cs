using Newtonsoft.Json;

namespace DockCheckWindows.Models
{
    public class ProjectAdmin
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("project_id")]
        public string ProjectId { get; set; }

        [JsonProperty("user_id")]
        public string UserId { get; set; }

        // Constructor
        public ProjectAdmin(string id, string projectId, string userId)
        {
            Id = id;
            ProjectId = projectId;
            UserId = userId;
        }

        // Default constructor for JSON deserialization
        public ProjectAdmin() { }

        // Method to deserialize JSON string to ProjectAdmin object
        public static ProjectAdmin FromJson(string jsonData)
        {
            return JsonConvert.DeserializeObject<ProjectAdmin>(jsonData);
        }

        // Method to serialize ProjectAdmin object to JSON string
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        // Method to create a new ProjectAdmin object with updated properties
        public ProjectAdmin CopyWith(string id = null, string projectId = null, string userId = null)
        {
            return new ProjectAdmin(
                id ?? Id,
                projectId ?? ProjectId,
                userId ?? UserId
            );
        }
    }
}
