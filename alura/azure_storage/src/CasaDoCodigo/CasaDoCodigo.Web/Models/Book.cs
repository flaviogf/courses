using System;
using System.Collections.Generic;

namespace CasaDoCodigo.Web.Models
{
    public class Book
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public ICollection<BookAuthor> Authors { get; set; }

        public File Image { get; set; }

        public File File { get; set; }
    }
}
