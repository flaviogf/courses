using System;
using System.Collections.Generic;
using AutoMapper;
using CourseLibrary.Api.Entities;
using CourseLibrary.Api.Models;
using CourseLibrary.Api.Services;
using Microsoft.AspNetCore.JsonPatch;
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
                var courseForCreation = _mapper.Map<Course>(courseForUpdate);

                courseForCreation.Id = courseId;

                _courseLibraryRepository.AddCourse(authorId, courseForCreation);

                _courseLibraryRepository.Save();

                var result = _mapper.Map<CourseDto>(courseForCreation);

                return CreatedAtRoute("GetAuthorCourse", new { authorId = authorId, courseId = courseForCreation.Id }, result);
            }

            _mapper.Map(courseForUpdate, course);

            _courseLibraryRepository.UpdateCourse(course);

            _courseLibraryRepository.Save();

            return NoContent();
        }

        [HttpPatch("{courseId}")]
        public ActionResult PartiallyUpdateCourseForAuthor(Guid authorId, Guid courseId, JsonPatchDocument<CourseForUpdateDto> patchDocument)
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

            var courseForUpdate = _mapper.Map<CourseForUpdateDto>(course);

            patchDocument.ApplyTo(courseForUpdate, ModelState);

            if (!TryValidateModel(courseForUpdate))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(courseForUpdate, course);

            _courseLibraryRepository.UpdateCourse(course);

            _courseLibraryRepository.Save();

            return NoContent();
        }
    }
}
