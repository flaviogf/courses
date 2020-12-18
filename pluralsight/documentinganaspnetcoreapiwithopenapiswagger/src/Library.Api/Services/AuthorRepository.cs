using System.Collections.Generic;
using Library.Api.Entities;

namespace Library.Api.Services
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ApplicationContext _context;

        public AuthorRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<Author> GetAuthors()
        {
            return _context.Authors;
        }
    }
}
