using CasaDoCodigo.Web.Lib;
using CasaDoCodigo.Web.ViewModels.ShoppingCart;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Web.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCart _shoppingCart;

        public ShoppingCartController(IShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        public async Task<IActionResult> Index()
        {
            var products = from product in await _shoppingCart.Products()
                           group product by product into grouping
                           orderby grouping.Key.Name ascending
                           select new IndexShoppingCartItemViewModel
                           {
                               Id = grouping.Key.Id,
                               Name = grouping.Key.Name,
                               Price = grouping.Key.Price,
                               Quantity = grouping.Count()
                           };

            var total = await _shoppingCart.Total();

            var viewModel = new IndexShoppingCartViewModel
            {
                Products = products,
                Total = total
            };

            return View(viewModel);
        }
    }
}
