using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BookList.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BookList.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class BooksController : ControllerBase
    {
        private readonly ApplicationContext _context;

        private readonly ILogger _logger;

        public BooksController
        (
            ApplicationContext context,
            ILogger<BooksController> logger
        )
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index([FromQuery] int page)
        {
            var limit = 10;

            var offset = page * limit - limit;

            var books = _context.Books.Skip(offset).Take(limit).ToList();

            return Ok(books);
        }

        [HttpPost]
        public async Task<IActionResult> StoreAsync([FromForm] BookViewModel viewModel)
        {
            var book = new Book
            {
                Name = viewModel.Name,
                Summary = viewModel.Summary,
                Status = (EBookStatus)viewModel.Status
            };

            if (viewModel.Cover != null)
            {
                using (var stream = new MemoryStream())
                {
                    await viewModel.Cover.CopyToAsync(stream);
                    book.Cover = stream.ToArray();
                }
            }

            await _context.Books.AddAsync(book);

            await _context.SaveChangesAsync();

            _logger.LogInformation($"|> Book created -> {book.Name}");

            return Ok(book);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromForm] BookViewModel viewModel)
        {
            var book = _context.Books.FirstOrDefault(it => it.Id == id);

            if (book == null)
            {
                return NotFound();
            }

            book.Name = viewModel.Name;
            book.Summary = viewModel.Summary;
            book.Status = (EBookStatus)viewModel.Status;

            if (viewModel.Cover != null)
            {
                using (var stream = new MemoryStream())
                {
                    await viewModel.Cover.CopyToAsync(stream);
                    book.Cover = stream.ToArray();
                }
            }

            await _context.SaveChangesAsync();

            _logger.LogInformation($"|> Book updated -> {book.Name}");

            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var book = _context.Books.FirstOrDefault(it => it.Id == id);

            if (book == null)
            {
                return NotFound();
            }

            _context.Books.Remove(book);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
