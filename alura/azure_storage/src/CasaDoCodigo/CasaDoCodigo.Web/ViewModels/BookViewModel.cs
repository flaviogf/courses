using System;
using System.Collections.Generic;

namespace CasaDoCodigo.Web.ViewModels
{
    public class BookViewModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public ICollection<AuthorViewModel> Authors { get; set; }
    }
}
