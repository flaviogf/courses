using CasaDoCodigo.Web.Database;
using CasaDoCodigo.Web.Lib;
using CasaDoCodigo.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Web.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ApplicationContext _context;

        private readonly IShoppingCart _shoppingCart;

        public ShoppingCartController(ApplicationContext context, IShoppingCart shoppingCart)
        {
            _context = context;
            _shoppingCart = shoppingCart;
        }

        public async Task<IActionResult> Store(int id)
        {
            var product = await _context.Products.FirstAsync(it => it.Id == id);

            await _shoppingCart.Add(product);

            TempData["Message"] = "Product has been added to shopping cart.";

            return Redirect("/");
        }

        public async Task<IActionResult> Index()
        {
            var products = from product in await _shoppingCart.Products()
                           group product by product into grouping
                           select new ShoppingCartItemViewModel
                           {
                               Id = grouping.Key.Id,
                               Name = grouping.Key.Name,
                               Price = grouping.Key.Price,
                               Quantity = grouping.Count()
                           };

            var viewModel = new ShoppingCartViewModel
            {
                Products = products
            };

            return View(viewModel);
        }
    }
}
