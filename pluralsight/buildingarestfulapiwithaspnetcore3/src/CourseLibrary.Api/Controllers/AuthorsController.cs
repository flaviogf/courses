using System;
using System.Collections.Generic;
using AutoMapper;
using CourseLibrary.Api.Models;
using CourseLibrary.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace CourseLibrary.Api.Controllers
{
    [ApiController]
    [Route("api/authors")]
    public class AuthorsController : ControllerBase
    {
        private readonly ICourseLibraryRepository _courseLibraryRepository;

        private readonly IMapper _mapper;

        public AuthorsController(ICourseLibraryRepository courseLibraryRepository, IMapper mapper)
        {
            _courseLibraryRepository = courseLibraryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AuthorDto>> GetAuthors([FromQuery] string mainCategory, [FromQuery] string searchQuery)
        {
            var authors = _courseLibraryRepository.GetAuthors(mainCategory, searchQuery);

            var result = _mapper.Map<IEnumerable<AuthorDto>>(authors);

            return Ok(result);
        }

        [HttpGet("{authorId}")]

        public IActionResult GetAuthor(Guid authorId)
        {
            var author = _courseLibraryRepository.GetAuthor(authorId);

            if (author == null)
            {
                return NotFound();
            }

            var result = _mapper.Map<AuthorDto>(author);

            return Ok(result);
        }
    }
}
