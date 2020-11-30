using System;
using System.Collections.Generic;

namespace CourseLibrary.Api.Entities
{
    public class Author
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string MainCategory { get; set; }

        public IList<Course> Courses { get; set; } = new List<Course>();
    }
}
