using System;
using System.Collections.Generic;
using AutoMapper;
using CourseLibrary.Api.Models;
using CourseLibrary.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace CourseLibrary.Api.Controllers
{
    [ApiController]
    [Route("api/authors/{authorId}/courses")]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseLibraryRepository _courseLibraryRepository;

        private readonly IMapper _mapper;

        public CoursesController(ICourseLibraryRepository courseLibraryRepository, IMapper mapper)
        {
            _courseLibraryRepository = courseLibraryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CourseDto>> GetAuthorCourses(Guid authorId)
        {
            if (!_courseLibraryRepository.AuthorExists(authorId))
            {
                return NotFound();
            }

            var courses = _courseLibraryRepository.GetCourses(authorId);

            var result = _mapper.Map<IEnumerable<CourseDto>>(courses);

            return Ok(result);
        }
    }
}
