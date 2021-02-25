using System;
using System.Threading.Tasks;
using AutoMapper;
using GloboTicket.Services.ShoppingBasket.Entities;
using GloboTicket.Services.ShoppingBasket.Models;
using GloboTicket.Services.ShoppingBasket.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GloboTicket.Services.ShoppingBasket.Controllers
{
    [ApiController]
    [Route("api/baskets")]
    public class BasketController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBasketRepository _basketRepository;

        public BasketController(IMapper mapper, IBasketRepository basketRepository)
        {
            _mapper = mapper;
            _basketRepository = basketRepository;
        }

        /// <summary>
        /// Create a Basket
        /// </summary>
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<BasketDto>> Post(BasketForCreationDto basketForCreationDto)
        {
            var basket = _mapper.Map<Basket>(basketForCreationDto);

            await _basketRepository.Add(basket);

            return CreatedAtAction(nameof(Get), new { basketId = basket.BasketId }, _mapper.Map<BasketDto>(basket));
        }

        /// <summary>
        /// Get a Basket
        /// </summary>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BasketDto>> Get(Guid basketId)
        {
            var basket = await _basketRepository.Get(basketId);

            if (basket == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<BasketDto>(basket));
        }
    }
}
