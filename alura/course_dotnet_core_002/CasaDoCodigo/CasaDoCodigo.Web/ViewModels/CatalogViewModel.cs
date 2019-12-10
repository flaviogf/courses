using CasaDoCodigo.Web.Models;
using System.Collections.Generic;

namespace CasaDoCodigo.Web.ViewModels
{
    public class CatalogViewModel
    {
        public IEnumerable<Product> Products { get; set; }
    }
}
