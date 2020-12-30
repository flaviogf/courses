using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Books.Api.Contexts;
using Books.Api.Entities;
using Books.Api.ExternalModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Books.Api.Services
{
    public class BooksRepository : IBooksRepository
    {
        private readonly BooksContext _context;

        private readonly IHttpClientFactory _httpClientFactory;

        private readonly ILogger<BooksRepository> _logger;

        public BooksRepository(BooksContext context, IHttpClientFactory httpClientFactory, ILogger<BooksRepository> logger)
        {
            _context = context;
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public IEnumerable<Book> GetBooks()
        {
            return _context
                .Books
                .Include(it => it.Author)
                .ToList();
        }

        public Book GetBook(Guid id)
        {
            return _context
                .Books
                .Include(it => it.Author)
                .FirstOrDefault(it => it.Id == id);
        }

        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            return await _context
                .Books
                .Include(it => it.Author)
                .ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetBooksAsync(IEnumerable<Guid> booksId)
        {
            return await _context
                .Books
                .Include(it => it.Author)
                .Where(it => booksId.Contains(it.Id))
                .ToListAsync();
        }

        public async Task<Book> GetBookAsync(Guid id)
        {
            return await _context
                .Books
                .Include(it => it.Author)
                .FirstOrDefaultAsync(it => it.Id == id);
        }

        public void AddBook(Book book)
        {
            book.Id = Guid.NewGuid();

            _context.Add(book);
        }

        public async Task<BookCover> GetBookCoverAsync(string coverId)
        {
            var httpClient = _httpClientFactory.CreateClient();

            var response = await httpClient.GetAsync($"http://localhost:5002/api/bookcovers/{coverId}");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            return JsonConvert.DeserializeObject<BookCover>(await response.Content.ReadAsStringAsync());
        }

        public async Task<IEnumerable<BookCover>> GetBookCoversAsync(Guid bookId)
        {
            var urls = new string[]
            {
                $"http://localhost:5002/api/bookcovers/{bookId}-dummy-1",
                $"http://localhost:5002/api/bookcovers/{bookId}-dummy-2?returnFault=true",
                $"http://localhost:5002/api/bookcovers/{bookId}-dummy-3",
                $"http://localhost:5002/api/bookcovers/{bookId}-dummy-4",
                $"http://localhost:5002/api/bookcovers/{bookId}-dummy-5",
            };

            var httpClient = _httpClientFactory.CreateClient();

            var cancellationTokenSource = new CancellationTokenSource();

            var token = cancellationTokenSource.Token;

            var tasks = urls.Select(async it =>
            {
                var response = await httpClient.GetAsync(it, token);

                if (!response.IsSuccessStatusCode)
                {
                    cancellationTokenSource.Cancel();

                    return null;
                }

                return JsonConvert.DeserializeObject<BookCover>(await response.Content.ReadAsStringAsync());
            });

            try
            {
                return await Task.WhenAll(tasks);
            }
            catch (OperationCanceledException ex)
            {
                _logger.LogError(ex, "Something goes wrong");

                return Array.Empty<BookCover>();
            }
        }

        public async Task<bool> SaveChangesAsync()
        {
            var result = await _context.SaveChangesAsync();

            return result > 0;
        }
    }
}
