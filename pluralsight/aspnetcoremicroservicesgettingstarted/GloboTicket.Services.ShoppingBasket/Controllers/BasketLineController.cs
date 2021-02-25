using System;
using System.Threading.Tasks;
using AutoMapper;
using GloboTicket.Services.ShoppingBasket.Entities;
using GloboTicket.Services.ShoppingBasket.Models;
using GloboTicket.Services.ShoppingBasket.Repositories;
using GloboTicket.Services.ShoppingBasket.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GloboTicket.Services.ShoppingBasket.Controllers
{
    [ApiController]
    [Route("api/baskets/{basketId}/basketLines")]
    public class BasketLineController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBasketRepository _basketRepository;
        private readonly IEventRepository _eventRepository;
        private readonly IEventCatalogService _eventCatalogService;

        public BasketLineController(IMapper mapper, IBasketRepository basketRepository, IEventRepository eventRepository, IEventCatalogService eventCatalogService)
        {
            _mapper = mapper;
            _basketRepository = basketRepository;
            _eventRepository = eventRepository;
            _eventCatalogService = eventCatalogService;
        }

        /// <summary>
        /// Create a Basket Line
        /// </summary>
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task Post(Guid basketId, BasketLineForCreationDto basketLineForCreationDto)
        {
            if (!(await _basketRepository.Exists(basketId)))
            {
                return;
            }

            var @event = await _eventCatalogService.GetEvent(basketLineForCreationDto.EventId);

            if (@event == null)
            {
                return;
            }

            if (!(await _eventRepository.Exists(basketLineForCreationDto.EventId)))
            {
                await _eventRepository.Add(@event);
            }

            if (!(await _basketRepository.BasketLineExists(basketId, basketLineForCreationDto.EventId)))
            {
                var basketLine = _mapper.Map<BasketLine>(basketLineForCreationDto);

                await _basketRepository.AddBasketLine(basketId, basketLine);

                return;
            }

            var existingBasketLine = await _basketRepository.GetBasketLine(basketId, basketLineForCreationDto.EventId);

            existingBasketLine.TicketAmount += basketLineForCreationDto.TicketAmount;

            await _basketRepository.UpdateBasketLine(basketId, existingBasketLine);
        }

        /// <summary>
        /// Get a Basket Line
        /// </summary>
        [HttpGet("{eventId}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BasketLineDto>> Get(Guid basketId, Guid eventId)
        {
            var basketLine = await _basketRepository.GetBasketLine(basketId, eventId);

            if (basketLine == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<BasketLineDto>(basketLine));
        }
    }
}
