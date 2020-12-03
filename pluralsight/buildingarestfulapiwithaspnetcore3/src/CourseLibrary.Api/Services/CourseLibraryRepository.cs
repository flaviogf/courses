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

        public IEnumerable<Author> GetAuthors(string mainCategory, string searchQuery)
        {
            var result = _context.Authors as IQueryable<Author>;

            if (!string.IsNullOrEmpty(mainCategory))
            {
                result = result.Where(it => it.MainCategory == mainCategory);
            }

            if (!string.IsNullOrEmpty(searchQuery))
            {
                result = result.Where(it => it.MainCategory.Contains(searchQuery) || it.FirstName.Contains(searchQuery) || it.LastName.Contains(searchQuery));
            }

            return result;
        }

        public Author GetAuthor(Guid authorId)
        {
            return _context.Authors.FirstOrDefault(it => it.Id == authorId);
        }

        public bool AuthorExists(Guid authorId)
        {
            return _context.Authors.Any(it => it.Id == authorId);
        }

        public IEnumerable<Course> GetCourses(Guid authorId)
        {
            return _context.Courses.Where(it => it.AuthorId == authorId);
        }

        public Course GetCourse(Guid authorId, Guid courseId)
        {
            return _context.Courses.FirstOrDefault(it => it.AuthorId == authorId && it.Id == courseId);
        }
    }
}
