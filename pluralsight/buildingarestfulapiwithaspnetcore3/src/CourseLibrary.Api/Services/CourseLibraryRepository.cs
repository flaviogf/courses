using System;
using System.Collections.Generic;
using System.Linq;
using CourseLibrary.Api.Entities;
using CourseLibrary.Api.ResourcesParameters;

namespace CourseLibrary.Api.Services
{
    public class CourseLibraryRepository : ICourseLibraryRepository
    {
        private readonly ApplicationContext _context;

        public CourseLibraryRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<Author> GetAuthors(AuthorsResourceParameter authorsResourceParameter)
        {
            var result = _context.Authors as IQueryable<Author>;

            if (!string.IsNullOrEmpty(authorsResourceParameter.MainCategory))
            {
                result = result.Where(it => it.MainCategory == authorsResourceParameter.MainCategory);
            }

            if (!string.IsNullOrEmpty(authorsResourceParameter.SearchQuery))
            {
                result = result.Where(it =>
                    it.MainCategory.Contains(authorsResourceParameter.SearchQuery) ||
                    it.FirstName.Contains(authorsResourceParameter.SearchQuery) ||
                    it.LastName.Contains(authorsResourceParameter.SearchQuery)
                );
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

        public void AddAuthor(Author author)
        {
            _context.Authors.Add(author);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
