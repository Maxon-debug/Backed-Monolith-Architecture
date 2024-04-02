using System.ComponentModel.DataAnnotations.Schema;

namespace MaxonEventManagement.Models
{
    public class Ticket
    {
        public Guid TicketId { get; set; }
        public string TicketName { get; set; } = string.Empty;
        public string TicketDescription { get; set;} = string.Empty;
        public int TicketPrice { get; set; }

        [ForeignKey("EventId")]
        public Event? ev { get; set; }
        public int EventId { get; set; }
        
    }
}
