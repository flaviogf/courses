using AutoMapper;
using GloboTicket.Services.EventCatalog.Entities;
using GloboTicket.Services.EventCatalog.Models;

namespace GloboTicket.Services.EventCatalog.Profiles
{
    public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<Event, EventDto>();
        }
    }
}
