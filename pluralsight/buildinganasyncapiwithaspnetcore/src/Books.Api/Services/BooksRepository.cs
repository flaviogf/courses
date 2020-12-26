using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Books.Api.Contexts;
using Books.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Books.Api.Services
{
    public class BooksRepository : IBooksRepository
    {
        private readonly BooksContext _context;

        public BooksRepository(BooksContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            return await _context
                .Books
                .Include(it => it.Author)
                .ToListAsync();
        }

        public async Task<Book> GetBookAsync(Guid id)
        {
            return await _context
                .Books
                .Include(it => it.Author)
                .FirstOrDefaultAsync(it => it.Id == id);
        }
    }
}
