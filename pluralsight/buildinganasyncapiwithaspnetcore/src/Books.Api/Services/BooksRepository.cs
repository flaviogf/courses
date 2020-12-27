using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<bool> SaveChangesAsync()
        {
            var result = await _context.SaveChangesAsync();

            return result > 0;
        }
    }
}
