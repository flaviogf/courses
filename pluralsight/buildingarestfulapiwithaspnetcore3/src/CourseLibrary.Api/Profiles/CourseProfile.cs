using AutoMapper;
using CourseLibrary.Api.Entities;
using CourseLibrary.Api.Models;

namespace CourseLibrary.Api.Profiles
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<Course, CourseDto>();
        }
    }
}
