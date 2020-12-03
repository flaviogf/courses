using System;
using System.Collections.Generic;
using AutoMapper;
using CourseLibrary.Api.Entities;
using CourseLibrary.Api.Models;
using CourseLibrary.Api.ResourcesParameters;
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
        public ActionResult<IEnumerable<AuthorDto>> GetAuthors([FromQuery] AuthorsResourceParameter authorsResourceParameter)
        {
            var authors = _courseLibraryRepository.GetAuthors(authorsResourceParameter);

            var result = _mapper.Map<IEnumerable<AuthorDto>>(authors);

            return Ok(result);
        }

        [HttpGet("{authorId}", Name= "GetAuthor")]
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

        [HttpPost]
        public IActionResult AddAuthor([FromBody] AuthorForCreationDto authorForCreation)
        {
            var author = _mapper.Map<Author>(authorForCreation);

            _courseLibraryRepository.AddAuthor(author);

            _courseLibraryRepository.Save();

            var result = _mapper.Map<AuthorDto>(author);

            return CreatedAtRoute("GetAuthor", new { authorId = author.Id }, result);
        }
    }
}
