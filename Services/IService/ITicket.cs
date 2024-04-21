using MaxonEventManagement.Models;

namespace MaxonEventManagement.Services.IService
{
    public interface ITicket
    {
        public Task<List<Ticket>> GetAllTickets();
        public Ticket GetTicket(Guid id);
        public string UpdateTicket(Ticket ticket);
        public string DeleteTicket(Ticket ticket);
        public Task<string> PurchaseTicket(Ticket ticket);
    }
}
