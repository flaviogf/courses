using System.Linq;
using AutoMapper;
using GloboTicket.Services.ShoppingBasket.Entities;
using GloboTicket.Services.ShoppingBasket.Models;

namespace GloboTicket.Services.ShoppingBasket.Profiles
{
    public class BasketProfile : Profile
    {
        public BasketProfile()
        {
            CreateMap<Basket, BasketDto>().ForMember(it => it.NumberOfItems, (o) => o.MapFrom(src => src.BasketLines.Sum(it => it.TicketAmount)));

            CreateMap<BasketForCreationDto, Basket>();
        }
    }
}
