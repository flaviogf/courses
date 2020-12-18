using System;

namespace Library.Api.Entities
{
    public class Book
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int? AmountOfPages { get; set; }

        public Guid AuthorId { get; set; }

        public Author Author { get; set; }
    }
}
