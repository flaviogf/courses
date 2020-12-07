using System.Collections.Generic;
using CourseLibrary.Api.Entities;
using CourseLibrary.Api.ResourceParameters;

namespace CourseLibrary.Api.Services
{
    public interface ICourseLibraryRepository
    {
        IEnumerable<Author> GetAuthors(AuthorResourceParameter authorResourceParameter);
    }
}
