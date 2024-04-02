using MaxonEventManagement.Data;
using MaxonEventManagement.Models;
using MaxonEventManagement.Servuces.IService;
using Microsoft.EntityFrameworkCore;

namespace MaxonEventManagement.Services
{
    public class EventService : IEvent
    {
        private readonly ApplicationDbContext _context;
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
           return await _context.Events.ToListAsync();
        }

        public async Task<Event> GetEvent( int id)
        {
            return await _context.Events.Where(x => x.EventId == id).FirstOrDefaultAsync();
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
