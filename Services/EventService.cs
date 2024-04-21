using MaxonEventManagement.Data;
using MaxonEventManagement.Models;
using MaxonEventManagement.Servuces.IService;
using Microsoft.EntityFrameworkCore;

namespace MaxonEventManagement.Services
{
    public class EventService : IEvent
    {
        public readonly ApplicationDbContext _context;
        public EventService(ApplicationDbContext context)
        {
            _context = context;
        }
        public string DeleteEvent(Event ev)
        {
             _context.Events.Remove(ev);
             _context.SaveChanges();
            return "Event Deleted Successifully";
        }

        public async Task<List<Event>> GetAllEvent()
        {
            //This line uses the include so that the event is returned with there corresponding tickets
            //To be implemented Later
           /*return await _context.Events.Include(x=>x.Tickets).ToListAsync();*/
           return await _context.Events.ToListAsync();
        }

        public Event GetEvent( int id)
        {
            return  _context.Events.Where(x => x.EventId == id).FirstOrDefault();
        }

        public string UpdateEvent(Event ev)
        {
            _context.Events.Update(ev);
            _context.SaveChanges();
            return "Event Updated Successifully";
        }
        public async Task<string> AddEvent(Event ev)
        {
            await _context.Events.AddAsync(ev);
            _context.SaveChanges();
            return "Event Added Successifully";
        }
    }
}
