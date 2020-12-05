using System.Collections.Generic;
using AutoMapper;
using CourseLibrary.Api.Entities;
using CourseLibrary.Api.Models;
using CourseLibrary.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace CourseLibrary.Api.Controllers
{
    [ApiController]
    [Route("api/authorscollection")]
    public class AuthorsCollectionController : ControllerBase
    {
        private readonly ICourseLibraryRepository _courseLibraryRepository;

        private readonly IMapper _mapper;

        public AuthorsCollectionController(ICourseLibraryRepository courseLibraryRepository, IMapper mapper)
        {
            _courseLibraryRepository = courseLibraryRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult<IEnumerable<AuthorDto>> CreateAuthors(IEnumerable<AuthorForCreationDto> authorsForCreation)
        {
            var authors = _mapper.Map<IEnumerable<Author>>(authorsForCreation);

            foreach (var it in authors)
            {
                _courseLibraryRepository.AddAuthor(it);
            }

            _courseLibraryRepository.Save();

            var results = _mapper.Map<IEnumerable<AuthorDto>>(authors);

            return Ok(results);
        }
    }
}
