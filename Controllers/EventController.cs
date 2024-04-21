using AutoMapper;
using MaxonEventManagement.Models;
using MaxonEventManagement.Services;
using MaxonEventManagement.Servuces.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MaxonEventManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        public readonly IEvent _eventService;
        public readonly IMapper _mapper;

        public EventController(IEvent eventService, IMapper mapper)
        {
            _eventService = eventService;
            _mapper = mapper;

        }
        [HttpGet]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<ActionResult<List<Event>>> GetAllEvent()
        {
            var events = await _eventService.GetAllEvent();
            return Ok(events);

        }
        [HttpPost]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<ActionResult<string>> AddEvent(EventDto eventDto)
        {
            var newEvent = _mapper.Map<Event>(eventDto);
            var response = await _eventService.AddEvent(newEvent);
            return Created($"Events/{newEvent.EventId}", response);
        }
        [HttpDelete("{id}")]
        public ActionResult<string>deleteEvent(int id)
        {
            var delEvent = _eventService.GetEvent(id);
            if (delEvent == null)
            {
                return NotFound("Event Not Found");
            }
            var response = _eventService.DeleteEvent(delEvent);
            return Ok(response);
        }
        [HttpGet("{id}")]
        public ActionResult<Event> GetEvent(int id)
        {
            var myEvent = _eventService.GetEvent(id);
            if (myEvent == null)
            {
                return NotFound("Event Not Found");
            }
            return Ok(myEvent);
        }
        [HttpPut("{id}")]
        public ActionResult<string> UpdateEvent(int id, EventDto updateEvent)
        {
            var myEvent = _eventService.GetEvent(id);
            if (myEvent == null)
            {
                return NotFound("Event Not Found");
            }
           
            var UpdatedEvent = _mapper.Map(updateEvent,myEvent);
            var response = _eventService.UpdateEvent(UpdatedEvent);
            return Ok(response);
        }

    }
}
