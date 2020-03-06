using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace CasaDoCodigo.Web.ViewModels.Book
{
    public class CreateBookViewModel
    {
        public string Title { get; set; }

        public IEnumerable<Guid> Authors { get; set; }

        public IEnumerable<SelectListItem> AuthorSelectList { get; set; }
    }
}
