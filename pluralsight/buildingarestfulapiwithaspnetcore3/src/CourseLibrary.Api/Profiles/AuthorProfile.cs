using AutoMapper;
using CourseLibrary.Api.Entities;
using CourseLibrary.Api.Helpers;
using CourseLibrary.Api.Models;

namespace CourseLibrary.Api.Profiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<Author, AuthorDto>()
                .ForMember(
                    dest => dest.Name,
                    source => source.MapFrom(it => $"{it.FirstName} {it.LastName}")
                )
                .ForMember(
                    dest => dest.Age,
                    source => source.MapFrom(it => it.DateOfBirth.GetCurrentAge())
                );
        }
    }
}
