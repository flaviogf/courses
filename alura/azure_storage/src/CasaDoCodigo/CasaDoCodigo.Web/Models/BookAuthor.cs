using System;

namespace CasaDoCodigo.Web.Models
{
    public class BookAuthor
    {
        public Book Book { get; set; }

        public Guid BookId { get; set; }

        public Author Author { get; set; }

        public Guid AuthorId { get; set; }
    }
}
