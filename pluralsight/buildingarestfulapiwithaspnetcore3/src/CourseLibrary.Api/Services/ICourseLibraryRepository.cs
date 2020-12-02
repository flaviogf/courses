using System;
using System.Collections.Generic;
using CourseLibrary.Api.Entities;

namespace CourseLibrary.Api.Services
{
    public interface ICourseLibraryRepository
    {
        IEnumerable<Author> GetAuthors();

        Author GetAuthor(Guid authorId);

        bool AuthorExists(Guid authorId);

        IEnumerable<Course> GetCourses(Guid authorId);
    }
}
