using System;
using CourseLibrary.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace CourseLibrary.Api.Controllers
{
    [ApiController]
    [Route("api/authors")]
    public class AuthorsController : ControllerBase
    {
        private readonly ICourseLibraryRepository _courseLibraryRepository;

        public AuthorsController(ICourseLibraryRepository courseLibraryRepository)
        {
            _courseLibraryRepository = courseLibraryRepository;
        }

        [HttpGet]
        public IActionResult GetAuthors()
        {
            var authors = _courseLibraryRepository.GetAuthors();

            return Ok(authors);
        }

        [HttpGet("{authorId}")]

        public IActionResult GetAuthor(Guid authorId)
        {
            var author = _courseLibraryRepository.GetAuthor(authorId);

            if (author == null)
            {
                return NotFound();
            }

            return Ok(author);
        }
    }
}
