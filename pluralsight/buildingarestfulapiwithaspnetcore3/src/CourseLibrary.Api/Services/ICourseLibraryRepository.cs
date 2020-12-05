using System;
using System.Collections.Generic;
using CourseLibrary.Api.Entities;
using CourseLibrary.Api.ResourcesParameters;

namespace CourseLibrary.Api.Services
{
    public interface ICourseLibraryRepository
    {
        IEnumerable<Author> GetAuthors(AuthorsResourceParameter authorsResourceParameter);

        Author GetAuthor(Guid authorId);

        bool AuthorExists(Guid authorId);

        IEnumerable<Course> GetCourses(Guid authorId);

        Course GetCourse(Guid authorId, Guid courseId);

        void AddAuthor(Author author);

        void AddCourse(Guid authorId, Course course);

        void Save();
    }
}
