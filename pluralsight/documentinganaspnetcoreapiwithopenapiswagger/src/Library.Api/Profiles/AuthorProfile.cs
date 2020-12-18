using AutoMapper;
using Library.Api.Entities;
using Library.Api.Models;

namespace Library.Api.Profiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<Author, AuthorDto>();

            CreateMap<AuthorForUpdateDto, Author>();
        }
    }
}
