using System;
using System.Collections.Generic;
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
        public async Task<ActionResult<BasketLineDto>> Post(Guid basketId, BasketLineForCreationDto basketLineForCreationDto)
        {
            if (!(await _basketRepository.Exists(basketId)))
            {
                return BadRequest();
            }

            var @event = await _eventCatalogService.GetEvent(basketLineForCreationDto.EventId);

            if (@event == null)
            {
                return BadRequest();
            }

            if (!(await _eventRepository.Exists(basketLineForCreationDto.EventId)))
            {
                await _eventRepository.Add(@event);
            }

            if (!(await _basketRepository.BasketLineExists(basketId, basketLineForCreationDto.EventId)))
            {
                var basketLine = _mapper.Map<BasketLine>(basketLineForCreationDto);

                await _basketRepository.AddBasketLine(basketId, basketLine);

                return CreatedAtAction(nameof(Get), new { basketId = basketLine.BasketId, eventId = basketLine.EventId }, _mapper.Map<BasketLineDto>(basketLine));
            }

            var existingBasketLine = await _basketRepository.GetBasketLine(basketId, basketLineForCreationDto.EventId);

            existingBasketLine.TicketAmount += basketLineForCreationDto.TicketAmount;

            await _basketRepository.UpdateBasketLine(basketId, existingBasketLine);

            return CreatedAtAction(nameof(Get), new { basketId = existingBasketLine.BasketId, eventId = existingBasketLine.EventId }, _mapper.Map<BasketLineDto>(existingBasketLine));
        }

        /// <summary>
        /// Get all Basket Lines
        /// </summary>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<BasketLineDto>>> Get(Guid basketId)
        {
            if (!(await _basketRepository.Exists(basketId)))
            {
                return NotFound();
            }

            var basketLines = await _basketRepository.GetAllBasketLines(basketId);

            return Ok(_mapper.Map<IEnumerable<BasketLineDto>>(basketLines));
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

        /// <summary>
        /// Update a Basket Line
        /// </summary>
        [HttpPut("{eventId}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Update(Guid basketId, Guid eventId, BasketLineForUpdateDto basketLineForUpdateDto)
        {
            var basketLine = await _basketRepository.GetBasketLine(basketId, eventId);

            if (basketLine == null)
            {
                return NotFound();
            }

            _mapper.Map(basketLineForUpdateDto, basketLine);

            await _basketRepository.UpdateBasketLine(basketId, basketLine);

            return NoContent();
        }

        /// <summary>
        /// Delete a Basket Line
        /// </summary>
        [HttpDelete("{eventId}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(Guid basketId, Guid eventId)
        {
            var basketLine = await _basketRepository.GetBasketLine(basketId, eventId);

            if (basketLine == null)
            {
                return NotFound();
            }

            await _basketRepository.RemoveBasketLine(basketId, basketLine);

            return NoContent();
        }
    }
}
