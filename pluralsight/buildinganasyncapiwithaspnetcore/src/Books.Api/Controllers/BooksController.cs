using System;
using System.Threading.Tasks;
using AutoMapper;
using Books.Api.Entities;
using Books.Api.Filters;
using Books.Api.Models;
using Books.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Books.Api.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private readonly IBooksRepository _booksRepository;

        private readonly IMapper _mapper;

        public BooksController(IBooksRepository booksRepository, IMapper mapper)
        {
            _booksRepository = booksRepository;
            _mapper = mapper;
        }

        [BooksResultFilter]
        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var books = await _booksRepository.GetBooksAsync();

            return Ok(books);
        }

        [BookResultFilter]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBook(Guid id)
        {
            var book = await _booksRepository.GetBookAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            var bookCovers = await _booksRepository.GetBookCoverAsync("dummy");

            return Ok(book);
        }

        [HttpPost]
        public async Task<ActionResult<BookDto>> CreateBook(BookForCreationDto bookForCreation)
        {
            var book = _mapper.Map<Book>(bookForCreation);

            _booksRepository.AddBook(book);

            await _booksRepository.SaveChangesAsync();

            await _booksRepository.GetBookAsync(book.Id);

            return CreatedAtAction(nameof(GetBook), new { id = book.Id }, _mapper.Map<BookDto>(book));
        }
    }
}
