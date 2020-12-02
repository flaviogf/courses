using System;

namespace CourseLibrary.Api.Models
{
    public class CourseDto
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public Guid AuthorId { get; set; }
    }
}
