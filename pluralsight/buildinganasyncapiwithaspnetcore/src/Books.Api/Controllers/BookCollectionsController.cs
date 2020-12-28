using System;
using System.Collections.Generic;
using System.Linq;
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
    [Route("api/bookcollections")]
    [BooksResultFilter]
    public class BookCollectionsController : ControllerBase
    {
        private readonly IBooksRepository _booksRepository;
        private readonly IMapper _mapper;

        public BookCollectionsController(IBooksRepository booksRepository, IMapper mapper)
        {
            _booksRepository = booksRepository;
            _mapper = mapper;
        }

        [HttpGet("({booksId})")]
        public async Task<IActionResult> GetBookCollection([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> booksId)
        {
            var books = await _booksRepository.GetBooksAsync(booksId);

            if (books.Count() != booksId.Count())
            {
                return NotFound();
            }

            return Ok(books);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBookCollection(IEnumerable<BookForCreationDto> booksForCreation)
        {
            var books = _mapper.Map<IEnumerable<Book>>(booksForCreation);

            foreach (var it in books)
            {
                _booksRepository.AddBook(it);
            }

            await _booksRepository.SaveChangesAsync();

            return Ok();
        }
    }
}
