using MaxonEventManagement.Data;
using MaxonEventManagement.Models;
using MaxonEventManagement.Services.IService;
using Microsoft.EntityFrameworkCore;

namespace MaxonEventManagement.Services
{
    public class TicketService : ITicket
    {
        public readonly ApplicationDbContext _context;
        public TicketService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<string> PurchaseTicket(Ticket ticket)
        {
            await _context.Tickets.AddAsync(ticket);
            _context.SaveChanges();
            return "Ticket Added Successifully";
        }

        public string DeleteTicket(Ticket ticket)
        {
            _context.Tickets.Remove(ticket);
            _context.SaveChanges();
            return "Ticket removed Successifully";
        }

        public async Task<List<Ticket>> GetAllTickets()
        {
            return await _context.Tickets.ToListAsync();
        }

        public Ticket GetTicket(Guid id)
        {
            return _context.Tickets.Where(x => x.TicketId == id).FirstOrDefault();
        }

        public string UpdateTicket(Ticket ticket)
        {
            _context.Tickets.Update(ticket);
            _context.SaveChanges();
            return "Event Updated Successifully";
        }
    }
}
