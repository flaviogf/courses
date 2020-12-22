using System;

namespace Library.Api.Models
{
    public class BookWithConcatenatedAuthorNameDto
    {
        public Guid Id { get; set; }

        public string Author { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}
