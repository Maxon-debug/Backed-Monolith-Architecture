using AutoMapper;
using MaxonEventManagement.Models;

namespace MaxonEventManagement.Profiles
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<EventDto, Event>().ReverseMap();
            CreateMap<AddTicketDto, Ticket>().ReverseMap();
            CreateMap<TicketResponseDto, Ticket>().ReverseMap();
            CreateMap<AddUserDto, User>().ReverseMap();
        }
    }
}
