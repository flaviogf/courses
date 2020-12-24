using System;
using System.Collections.Generic;
using AutoMapper;
using Library.Api.Models;
using Library.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/authors")]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepository;

        private readonly IMapper _mapper;

        public AuthorsController(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Get a list of authors
        /// </summary>
        /// <returns>An ActionResult of type IEnumerable of AuthorDto</returns>
        [HttpGet]
        public ActionResult<IEnumerable<AuthorDto>> GetAuthors()
        {
            return Ok(_mapper.Map<IEnumerable<AuthorDto>>(_authorRepository.GetAuthors()));
        }

        /// <summary>
        /// Get an author by his/her id
        /// </summary>
        /// <param name="authorId">The id of the author you want to get</param>
        /// <returns>An ActionResult of type AuthorDto</returns>
        [HttpGet("{authorId}")]
        public ActionResult<AuthorDto> GetAuthor(Guid authorId)
        {
            var author = _authorRepository.GetAuthor(authorId);

            if (author == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<AuthorDto>(author));
        }

        /// <summary>
        /// Update an author
        ///</summary>
        /// <param name="authorId">The id of the author to update</param>
        /// <param name="authorForUpdate">The author with the updated values</param>
        /// <returns>An ActionResult of type AuthorDto</returns>
        [HttpPut("{authorId}")]
        public ActionResult<AuthorDto> UpdateAuthor(Guid authorId, AuthorForUpdateDto authorForUpdate)
        {
            var author = _authorRepository.GetAuthor(authorId);

            if (author == null)
            {
                return NotFound();
            }

            _mapper.Map(authorForUpdate, author);

            _authorRepository.UpdateAuthor(author);

            _authorRepository.SaveChanges();

            return Ok(_mapper.Map<AuthorDto>(author));
        }
    }
}
