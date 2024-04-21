using System.ComponentModel.DataAnnotations.Schema;

namespace MaxonEventManagement.Models
{
    public class TicketResponseDto
    {
        public Guid TicketId { get; set; }
        public string TicketName { get; set; } = string.Empty;
        public string TicketDescription { get; set; } = string.Empty;
        public int TicketPrice { get; set; }
        public int EventId { get; set; }
    }
}
