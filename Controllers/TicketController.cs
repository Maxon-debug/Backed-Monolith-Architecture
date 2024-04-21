using AutoMapper;
using MaxonEventManagement.Models;
using MaxonEventManagement.Services;
using MaxonEventManagement.Services.IService;
using MaxonEventManagement.Servuces.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MaxonEventManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        public readonly ITicket _ticketService;
        public readonly IMapper _mapper;
        public TicketController(ITicket ticketService, IMapper mapper)
        {
            _mapper = mapper;
            _ticketService = ticketService;
        }
        [HttpGet]
        public async Task<ActionResult<List<TicketResponseDto>>> GetAllTickets()
        {
            var mytickets = await _ticketService.GetAllTickets();
            //Created a mapping to ensure that only required column are returned.
            var response =_mapper.Map<List<TicketResponseDto>>(mytickets);
            return Ok(response);
        }
        [HttpGet("{id}")]
        public ActionResult<Ticket> GetTicket(Guid id)
        {
            var myTicket = _ticketService.GetTicket(id);
            if (myTicket == null)
            {
                return NotFound("Ticket Not Found");
            }
            return Ok(myTicket);
        }
        [HttpPost]
        public async Task<ActionResult<string>> PurchaseTicket(AddTicketDto addTicketDto)
        {
            var newTicket = _mapper.Map<Ticket>(addTicketDto);
            var response = await _ticketService.PurchaseTicket(newTicket);
            //return Created($"Tickets/{newTicket.TicketId}",response);
            return Ok(response);

        }
        [HttpDelete("{id}")]
        public ActionResult<string> DeleteTicket(Guid id)
        {
            var delTicket = _ticketService.GetTicket(id);
            if (delTicket == null)
            {
                return NotFound("Ticket Not Found");
            }
            var response = _ticketService.DeleteTicket(delTicket);
            return Ok(response);
        }
        [HttpPut("{id}")]
        public ActionResult<string> UpdateTicket(Guid id, AddTicketDto addTicketDto)
        {
            var myTicket = _ticketService.GetTicket(id);
            if (myTicket == null)
            {
                return NotFound("Ticket Not Found");
            }

            var UpdatedEvent = _mapper.Map(addTicketDto, myTicket);
            var response = _ticketService.UpdateTicket(UpdatedEvent);
            return Ok(response);
        }

    }
}
