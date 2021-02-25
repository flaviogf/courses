using AutoMapper;
using GloboTicket.Services.ShoppingBasket.Entities;
using GloboTicket.Services.ShoppingBasket.Models;

namespace GloboTicket.Services.ShoppingBasket.Profiles
{
    public class BasketLineProfile : Profile
    {
        public BasketLineProfile()
        {
            CreateMap<BasketLine, BasketLineDto>();

            CreateMap<BasketLineForCreationDto, BasketLine>();
        }
    }
}
