using System;
using System.Collections.Generic;
using System.Linq;
using Library.Api.Entities;
using Microsoft.EntityFrameworkCore;

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

        public Author GetAuthor(Guid authorId)
        {
            return _context.Authors.FirstOrDefault(it => it.Id == authorId);
        }

        public void UpdateAuthor(Author author)
        {

        }

        public Book GetBook(Guid authorId, Guid bookId)
        {
            return _context.Books.Include(it => it.Author).FirstOrDefault(it => it.AuthorId == authorId && it.Id == bookId);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
