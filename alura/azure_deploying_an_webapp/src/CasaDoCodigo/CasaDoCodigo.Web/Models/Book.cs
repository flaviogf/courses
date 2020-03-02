using System;
using System.Collections.Generic;

namespace CasaDoCodigo.Web.Models
{
    public class Book
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public IList<AuthorBooks> Authors { get; set; }
    }
}
