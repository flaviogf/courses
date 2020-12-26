using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Books.Api.Entities;

namespace Books.Api.Services
{
    public interface IBooksRepository
    {
        Task<IEnumerable<Book>> GetBooksAsync();

        Task<Book> GetBookAsync(Guid id);
    }
}
