using System.Collections.Generic;
using AutoMapper;
using Books.Api.Entities;
using Books.Api.ExternalModels;
using Books.Api.Models;

namespace Books.Api.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookDto>()
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src => $"{src.Author.FirstName} {src.Author.LastName}"));

            CreateMap<BookForCreationDto, Book>();

            CreateMap<Book, BookWithCoverDto>()
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src => $"{src.Author.FirstName} {src.Author.LastName}"));

            CreateMap<IEnumerable<BookCover>, BookWithCoverDto>()
                .ForMember(dest => dest.BookCovers, opt => opt.MapFrom(src => src));

            CreateMap<BookCover, BookCoverDto>();
        }
    }
}
