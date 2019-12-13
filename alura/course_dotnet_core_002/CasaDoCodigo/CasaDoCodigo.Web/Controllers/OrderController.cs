using CasaDoCodigo.Web.Database;
using CasaDoCodigo.Web.Lib;
using CasaDoCodigo.Web.Models;
using CasaDoCodigo.Web.ViewModels.Order;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationContext _context;

        private readonly IAuth _auth;

        private readonly IShoppingCart _shoppingCart;

        public OrderController(ApplicationContext context, IAuth auth, IShoppingCart shoppingCart)
        {
            _context = context;
            _auth = auth;
            _shoppingCart = shoppingCart;
        }

        public async Task<IActionResult> Show()
        {
            var user = await _auth.User();

            var products = from product in await _shoppingCart.Products()
                           group product by product into grouping
                           select new OrderItemViewModel
                           {
                               Id = grouping.Key.Id,
                               Name = grouping.Key.Name,
                               Price = grouping.Key.Price,
                               Quantity = grouping.Count()
                           };

            var viewModel = new OrderViewModel
            {
                Name = user.Name,
                Email = user.Email,
                Phone = user.Phone,
                ZipCode = user.Address.ZipCode,
                Street = user.Address.Street,
                District = user.Address.District,
                City = user.Address.City,
                State = user.Address.State,
                Products = products
            };

            return View(viewModel);
        }

        public async Task<IActionResult> Store()
        {
            var user = await _auth.User();

            var products = (from product in await _shoppingCart.Products()
                            group product by product into grouping
                            select new OrderProduct
                            {
                                ProductId = grouping.Key.Id,
                                Quantity = grouping.Count()
                            })
                            .ToList();

            var order = new Order
            {
                UserId = user.Id,
                Products = products
            };

            await _context.Orders.AddAsync(order);

            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Catalog");
        }
    }
}
