using System.Collections.Generic;
using System.Linq;
using CourseLibrary.Api.Entities;
using CourseLibrary.Api.ResourceParameters;

namespace CourseLibrary.Api.Services
{
    public class CourseLibraryRepository : ICourseLibraryRepository
    {
        private readonly ApplicationContext _context;

        public CourseLibraryRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<Author> GetAuthors(AuthorResourceParameter authorResourceParameter)
        {
            var query = _context.Authors as IQueryable<Author>;

            if (!string.IsNullOrWhiteSpace(authorResourceParameter.MainCategory))
            {
                query = query.Where(it => it.MainCategory == authorResourceParameter.MainCategory);
            }

            if (!string.IsNullOrWhiteSpace(authorResourceParameter.SearchQuery))
            {
                query = query.Where(it => it.FirstName.Contains(authorResourceParameter.SearchQuery) || it.LastName.Contains(authorResourceParameter.SearchQuery) || it.MainCategory.Contains(authorResourceParameter.SearchQuery));
            }

            return query.ToList();
        }
    }
}
