using System;
using System.Collections.Generic;
using CourseLibrary.Api.Entities;
using CourseLibrary.Api.ResourcesParameters;

namespace CourseLibrary.Api.Services
{
    public interface ICourseLibraryRepository
    {
        IEnumerable<Author> GetAuthors(AuthorsResourceParameter authorsResourceParameter);

        IEnumerable<Author> GetAuthors(IEnumerable<Guid> ids);

        Author GetAuthor(Guid authorId);

        bool AuthorExists(Guid authorId);

        void AddAuthor(Author author);

        IEnumerable<Course> GetCourses(Guid authorId);

        Course GetCourse(Guid authorId, Guid courseId);

        void AddCourse(Guid authorId, Course course);

        void UpdateCourse(Course course);

        void Save();
    }
}
