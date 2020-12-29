using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Books.Api.Entities;
using Books.Api.ExternalModels;

namespace Books.Api.Services
{
    public interface IBooksRepository
    {
        IEnumerable<Book> GetBooks();

        Book GetBook(Guid id);

        Task<IEnumerable<Book>> GetBooksAsync();

        Task<IEnumerable<Book>> GetBooksAsync(IEnumerable<Guid> booksId);

        Task<Book> GetBookAsync(Guid id);

        void AddBook(Book book);

        Task<BookCover> GetBookCoverAsync(string coverId);

        Task<IEnumerable<BookCover>> GetBookCoversAsync(Guid bookId);

        Task<bool> SaveChangesAsync();
    }
}
