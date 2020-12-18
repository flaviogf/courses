using System.Collections.Generic;
using Library.Api.Entities;

namespace Library.Api.Services
{
    public interface IAuthorRepository
    {
        IEnumerable<Author> GetAuthors();
    }
}
