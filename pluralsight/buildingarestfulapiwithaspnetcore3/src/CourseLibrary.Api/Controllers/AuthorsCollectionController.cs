using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CourseLibrary.Api.Entities;
using CourseLibrary.Api.Helpers;
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

        [HttpGet("({ids})", Name = "GetAuthorCollection")]
        public ActionResult<IEnumerable<AuthorDto>> GetAuthorCollection([FromRoute, ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
        {
            if (ids == null)
            {
                return BadRequest();
            }

            var authors = _courseLibraryRepository.GetAuthors(ids);

            if (authors.Count() != ids.Count())
            {
                return NotFound();
            }

            var results = _mapper.Map<IEnumerable<AuthorDto>>(authors);

            return Ok(results);
        }

        [HttpPost]
        public ActionResult<IEnumerable<AuthorDto>> CreateAuthorCollection(IEnumerable<AuthorForCreationDto> authorsForCreation)
        {
            var authors = _mapper.Map<IEnumerable<Author>>(authorsForCreation);

            foreach (var it in authors)
            {
                _courseLibraryRepository.AddAuthor(it);
            }

            _courseLibraryRepository.Save();

            var results = _mapper.Map<IEnumerable<AuthorDto>>(authors);

            var ids = string.Join(',', results.Select(it => it.Id));

            return CreatedAtRoute("GetAuthorCollection", new { ids = ids }, results);
        }
    }
}
