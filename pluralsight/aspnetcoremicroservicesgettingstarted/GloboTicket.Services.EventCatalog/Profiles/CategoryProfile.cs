using AutoMapper;
using GloboTicket.Services.EventCatalog.Entities;
using GloboTicket.Services.EventCatalog.Models;

namespace GloboTicket.Services.EventCatalog.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDto>();
        }
    }
}
