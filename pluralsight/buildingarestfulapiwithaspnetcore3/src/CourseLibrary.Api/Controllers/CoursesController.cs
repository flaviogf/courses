using System;
using System.Collections.Generic;
using AutoMapper;
using CourseLibrary.Api.Entities;
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

        [HttpGet("{courseId}", Name = "GetAuthorCourse")]
        public ActionResult<CourseDto> GetAuthorCourse(Guid authorId, Guid courseId)
        {
            if (!_courseLibraryRepository.AuthorExists(authorId))
            {
                return NotFound();
            }

            var course = _courseLibraryRepository.GetCourse(authorId, courseId);

            if (course == null)
            {
                return NotFound();
            }

            var result = _mapper.Map<CourseDto>(course);

            return Ok(course);
        }

        [HttpPost]
        public ActionResult<CourseDto> CreateCourseForAuthor([FromRoute] Guid authorId, [FromBody] CourseForCreationDto courseForCreation)
        {
            if (!_courseLibraryRepository.AuthorExists(authorId))
            {
                return NotFound();
            }

            var course = _mapper.Map<Course>(courseForCreation);

            _courseLibraryRepository.AddCourse(authorId, course);

            _courseLibraryRepository.Save();

            var result = _mapper.Map<CourseDto>(course);

            return CreatedAtRoute("GetAuthorCourse", new { authorId = authorId, courseId = course.Id }, result);
        }

        [HttpPut("{courseId}")]
        public ActionResult UpdateCourseForAuthor(Guid authorId, Guid courseId, CourseForUpdateDto courseForUpdate)
        {
            if (!_courseLibraryRepository.AuthorExists(authorId))
            {
                return NotFound();
            }

            var course = _courseLibraryRepository.GetCourse(authorId, courseId);

            if (course == null)
            {
                return NotFound();
            }

            _mapper.Map(courseForUpdate, course);

            _courseLibraryRepository.UpdateCourse(course);

            _courseLibraryRepository.Save();

            return NoContent();
        }
    }
}
