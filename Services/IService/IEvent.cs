using MaxonEventManagement.Models;

namespace MaxonEventManagement.Servuces.IService
{
    public interface IEvent
    {
        public Task<List<Event>> GetAllEvent();
        public Event GetEvent(int id);
        public string UpdateEvent(Event ev);
        public string DeleteEvent(Event ev);
        public Task<string> AddEvent(Event ev);
    }
}
