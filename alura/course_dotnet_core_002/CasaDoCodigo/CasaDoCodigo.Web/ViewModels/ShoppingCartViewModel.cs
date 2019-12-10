using System.Collections.Generic;

namespace CasaDoCodigo.Web.ViewModels
{
    public class ShoppingCartViewModel
    {
        public IEnumerable<ShoppingCartItemViewModel> Products { get; set; }
    }
}
