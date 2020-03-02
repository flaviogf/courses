using System;
using System.Collections.Generic;

namespace CasaDoCodigo.Web.Models
{
    public class Author
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public IList<AuthorBooks> Books { get; set; }
    }
}
