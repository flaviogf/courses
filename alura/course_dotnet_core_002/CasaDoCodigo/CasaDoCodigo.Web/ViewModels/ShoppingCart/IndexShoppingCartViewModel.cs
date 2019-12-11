using System.Collections.Generic;

namespace CasaDoCodigo.Web.ViewModels.ShoppingCart
{
    public class IndexShoppingCartViewModel
    {
        public IEnumerable<IndexShoppingCartItemViewModel> Products { get; set; }

        public int Total { get; set; }
    }
}
