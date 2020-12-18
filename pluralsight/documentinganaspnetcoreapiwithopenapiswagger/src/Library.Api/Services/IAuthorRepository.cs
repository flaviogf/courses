using System;
using System.Collections.Generic;
using Library.Api.Entities;

namespace Library.Api.Services
{
    public interface IAuthorRepository
    {
        IEnumerable<Author> GetAuthors();

        Author GetAuthor(Guid authorId);
    }
}
