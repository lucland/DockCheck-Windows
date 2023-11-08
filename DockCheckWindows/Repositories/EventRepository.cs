using DockCheckWindows.Models;
using DockCheckWindows.Services;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace DockCheckWindows.Repositories
{
    public class EventRepository : BaseRepository<Event>
    {
        private const string BaseUrl = "http://localhost:3000/api/v1/events";

        public EventRepository(ApiService apiService)
            : base(apiService)
        {
        }

        public async Task<Event> GetEventByIdAsync(string id)
        {
            var json = await GetAsync($"{BaseUrl}/{id}");
            return JsonConvert.DeserializeObject<Event>(json);
        }

        public async Task<string> GetAllEventsAsync(int limit, int offset)
        {
            return await GetAsync($"{BaseUrl}?limit={limit}&offset={offset}");
        }

        public async Task<Event> CreateEventAsync(Event eventItem)
        {
            var json = JsonConvert.SerializeObject(eventItem);
            var response = await PostAsync($"{BaseUrl}/create", json, "Event");
            return JsonConvert.DeserializeObject<Event>(response);
        }

        // Additional methods for syncing events, etc., can be added here.
    }
}
