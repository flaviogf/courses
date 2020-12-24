using System;
using System.Collections.Generic;
using AutoMapper;
using Library.Api.Attributes;
using Library.Api.Entities;
using Library.Api.Models;
using Library.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace Library.Api.Controllers
{
    [ApiController]
    [Produces("application/json", "application/xml")]
    [Route("api/v{version:apiVersion}/authors/{authorId}/books")]
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
        /// Get the books for a specific author
        /// </summary>
        /// <param name="authorId">The id of the book author</param>
        /// <returns>An ActionResult of type IEnumerable of Book</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<BookDto>> GetBooks(Guid authorId)
        {
            if (!_authorRepository.AuthorExists(authorId))
            {
                return NotFound();
            }

            var books = _authorRepository.GetBooks(authorId);

            return Ok(_mapper.Map<IEnumerable<BookDto>>(books));
        }

        /// <summary>
        /// Get a book by id for a specific author
        /// </summary>
        /// <param name="authorId">The id of the book author</param>
        /// <param name="bookId">The id of the book</param>
        /// <returns>An ActionResult of type Book</returns>
        /// <response code="200">Returns the requested book</response>
        [HttpGet("{bookId}", Name = "GetBook")]
        [Produces("application/vnd.marvin.book+json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [RequestHeaderMatchesMediaType(nameof(HeaderNames.Accept), "application/json", "application/vnd.marvin.book+json")]
        public ActionResult<BookDto> GetBook(Guid authorId, Guid bookId)
        {
            var book = _authorRepository.GetBook(authorId, bookId);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<BookDto>(book));
        }

        /// <summary>
        /// Get a book by id for a specific author
        /// </summary>
        /// <param name="authorId">The id of the book author</param>
        /// <param name="bookId">The id of the book</param>
        /// <returns>An ActionResult of type BookWithConcatenatedAuthorNameDto</returns>
        [HttpGet("{bookId}")]
        [Produces("application/vnd.marvin.bookwithconcatenatedauthorname+json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [RequestHeaderMatchesMediaType(nameof(HeaderNames.Accept), "application/json", "application/vnd.marvin.bookwithconcatenatedauthorname+json")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public ActionResult<BookWithConcatenatedAuthorNameDto> GetBookWithConcatenatedAuthorName(Guid authorId, Guid bookId)
        {
            var book = _authorRepository.GetBook(authorId, bookId);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<BookWithConcatenatedAuthorNameDto>(book));
        }

        /// <summary>
        /// Create a book for a specific author
        /// </summary>
        /// <param name="authorId">The id of the book author</param>
        /// <param name="bookForCreation">The book to create</param>
        /// <returns>An ActionResult of type BookDto</returns>
        /// <responses code="422">Validation error</responses>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public ActionResult<BookDto> CreateBook(Guid authorId, BookForCreationDto bookForCreation)
        {
            if (!_authorRepository.AuthorExists(authorId))
            {
                return NotFound();
            }

            var book = _mapper.Map<Book>(bookForCreation);

            _authorRepository.CreateBook(authorId, book);

            _authorRepository.SaveChanges();

            return CreatedAtAction(nameof(GetBook), new { authorId, bookId = book.Id }, _mapper.Map<BookDto>(book));
        }
    }
}
