using System;
using System.Linq;
using CourseLibrary.Api.Entities;
using CourseLibrary.Api.Helpers;
using CourseLibrary.Api.Models;
using CourseLibrary.Api.ResourceParameters;

namespace CourseLibrary.Api.Services
{
    public class CourseLibraryRepository : ICourseLibraryRepository
    {
        private readonly ApplicationContext _context;

        private readonly IPropertyMappingService _propertyMappingService;

        public CourseLibraryRepository(ApplicationContext context, IPropertyMappingService propertyMappingService)
        {
            _context = context;
            _propertyMappingService = propertyMappingService;
        }

        public PagedList<Author> GetAuthors(AuthorResourceParameter authorResourceParameter)
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

            if (!string.IsNullOrWhiteSpace(authorResourceParameter.OrderBy))
            {
                var propertyMappingDictionary = _propertyMappingService.GetPropertyMapping<AuthorDto, Author>();

                query = query.OrderBy(authorResourceParameter.OrderBy, propertyMappingDictionary);
            }

            return new PagedList<Author>(query, authorResourceParameter.PageNumber, authorResourceParameter.PageSize);
        }

        public Author GetAuthor(Guid authorId)
        {
            return _context.Authors.FirstOrDefault(it => it.Id == authorId);
        }
    }
}
