using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace CasaDoCodigo.Web.ViewModels.Book
{
    public class EditBookViewModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public IEnumerable<Guid> Authors { get; set; }

        public IEnumerable<SelectListItem> AuthorSelectList { get; set; }

        public string Cover { get; set; }
    }
}
