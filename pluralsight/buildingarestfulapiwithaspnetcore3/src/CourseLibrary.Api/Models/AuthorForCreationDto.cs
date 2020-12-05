using System;
using System.Collections.Generic;

namespace CourseLibrary.Api.Models
{
    public class AuthorForCreationDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string MainCategory { get; set; }

        public IEnumerable<CourseForCreationDto> Courses { get; set; } = new List<CourseForCreationDto>();
    }
}
