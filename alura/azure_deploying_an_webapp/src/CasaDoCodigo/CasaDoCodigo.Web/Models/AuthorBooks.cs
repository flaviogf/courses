using System;

namespace CasaDoCodigo.Web.Models
{
    public class AuthorBooks
    {
        public Guid AuthorId { get; set; }

        public Author Author { get; set; }

        public Guid BookId { get; set; }

        public Book Book { get; set; }
    }
}
