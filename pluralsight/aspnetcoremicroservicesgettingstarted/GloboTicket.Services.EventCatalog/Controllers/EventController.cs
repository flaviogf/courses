using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using GloboTicket.Services.EventCatalog.Models;
using GloboTicket.Services.EventCatalog.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GloboTicket.Services.EventCatalog.Controllers
{
    [ApiController]
    [Route("api/events")]
    public class EventController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IEventRepository _eventRepository;

        public EventController(IMapper mapper, IEventRepository eventRepository)
        {
            _mapper = mapper;
            _eventRepository = eventRepository;
        }

        /// <summary>
        /// Get all Events
        /// </summary>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<EventDto>>> GetAll(Guid categoryId)
        {
            var events = await _eventRepository.GetAll(categoryId);

            return Ok(_mapper.Map<IEnumerable<EventDto>>(events));
        }

        /// <summary>
        /// Get an Event
        /// </summary>
        [HttpGet("{eventId}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EventDto>> Get(Guid eventId)
        {
            var @event = await _eventRepository.Get(eventId);

            if (@event == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<EventDto>(@event));
        }
    }
}
