using Pratique.Entities;

namespace Pratique.Persistence
{
    public class EventsDBContext
    {
        public List<Event> Events { get; set; }

        public EventsDBContext()
        {
            Events = new List<Event>();
        }
    }
}
