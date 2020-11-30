using System;

namespace CourseLibrary.Api.Entities
{
    public class Course
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public Author Author { get; set; }

        public Guid AuthorId { get; set; }
    }
}
