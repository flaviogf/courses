using System;
using System.Collections.Generic;

namespace Library.Api.Entities
{
    public class Author
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public IList<Book> Books { get; set; } = new List<Book>();
    }
}
