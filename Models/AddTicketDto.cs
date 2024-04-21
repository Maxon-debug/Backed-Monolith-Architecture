namespace MaxonEventManagement.Models
{
    public class AddTicketDto
    {
        public string TicketName { get; set; } = string.Empty;
        public string TicketDescription { get; set; } = string.Empty;
        public int TicketPrice { get; set; }
        public int EventId { get; set; }
    }
}
