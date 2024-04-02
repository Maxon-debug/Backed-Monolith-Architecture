namespace MaxonEventManagement.Models
{
    public class EventDto
    {
        public int EventId { get; set; }
        public string EventName { get; set; } = string.Empty;
        public DateTime EventDate { get; set; } = DateTime.Now;
        public string EventLocation { get; set; } = string.Empty;
    }
}
