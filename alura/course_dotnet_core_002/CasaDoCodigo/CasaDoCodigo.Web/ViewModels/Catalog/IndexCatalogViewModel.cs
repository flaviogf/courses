using CasaDoCodigo.Web.Models;
using System.Collections.Generic;

namespace CasaDoCodigo.Web.ViewModels.Catalog
{
    public class IndexCatalogViewModel
    {
        public IEnumerable<Product> Products { get; set; }
    }
}
