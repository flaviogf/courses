using AutoMapper;
using Books.Api.Entities;
using Books.Api.Models;

namespace Books.Api.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookDto>()
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src => $"{src.Author.FirstName} {src.Author.LastName}"));
        }
    }
}
