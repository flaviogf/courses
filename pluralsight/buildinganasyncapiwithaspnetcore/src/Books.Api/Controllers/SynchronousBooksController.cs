using System.Collections.Generic;
using Books.Api.Entities;
using Books.Api.Filters;
using Books.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Books.Api.Controllers
{
    [ApiController]
    [Route("api/synchronousbooks")]
    public class SynchronousBooksController : ControllerBase
    {
        private readonly IBooksRepository _booksRepository;

        public SynchronousBooksController(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        [BooksResultFilter]
        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetBooks()
        {
            var books = _booksRepository.GetBooks();

            return Ok(books);
        }
    }
}
