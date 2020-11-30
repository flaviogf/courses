using System;
using System.Collections.Generic;
using System.Linq;
using CourseLibrary.Api.Entities;

namespace CourseLibrary.Api.Services
{
    public class CourseLibraryRepository : ICourseLibraryRepository
    {
        private readonly ApplicationContext _context;

        public CourseLibraryRepository(ApplicationContext context)
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
    }
}
