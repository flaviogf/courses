using System;
using CourseLibrary.Api.Entities;
using CourseLibrary.Api.Helpers;
using CourseLibrary.Api.ResourceParameters;

namespace CourseLibrary.Api.Services
{
    public interface ICourseLibraryRepository
    {
        PagedList<Author> GetAuthors(AuthorResourceParameter authorResourceParameter);

        Author GetAuthor(Guid authorId);
    }
}
