using System;
using AutoMapper;
using Library.Api.Models;
using Library.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
{
    [ApiController]
    [Route("api/authors/{authorId}/books")]
    public class BooksController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepository;

        private readonly IMapper _mapper;

        public BooksController(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Get a book by id for a specific author
        /// </summary>
        /// <param name="authorId">The id of the book author</param>
        /// <param name="bookId">The id of the book</param>
        /// <returns>An ActionResult of type Book</returns>
        /// <response code="200">Returns the requested book</response>
        [HttpGet("{bookId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<BookDto> GetBook(Guid authorId, Guid bookId)
        {
            var book = _authorRepository.GetBook(authorId, bookId);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<BookDto>(book));
        }
    }
}
