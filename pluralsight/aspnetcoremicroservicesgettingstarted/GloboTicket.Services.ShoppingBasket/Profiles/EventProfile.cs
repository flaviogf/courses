using AutoMapper;
using GloboTicket.Services.ShoppingBasket.Entities;
using GloboTicket.Services.ShoppingBasket.Models;

namespace GloboTicket.Services.ShoppingBasket.Profiles
{
    public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<Event, EventDto>();
        }
    }
}
