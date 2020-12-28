using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Books.Api.Entities;
using Books.Api.Models;
using Books.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Books.Api.Controllers
{
    [ApiController]
    [Route("api/bookcollections")]
    public class BookCollectionsController : ControllerBase
    {
        private readonly IBooksRepository _booksRepository;
        private readonly IMapper _mapper;

        public BookCollectionsController(IBooksRepository booksRepository, IMapper mapper)
        {
            _booksRepository = booksRepository;
            _mapper = mapper;
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
