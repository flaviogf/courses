using System;
using System.Linq;
using CasaDoCodigo.Web.Infrastrucutre;
using CasaDoCodigo.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace CasaDoCodigo.Web.Controllers
{
    public class BasketController : Controller
    {
        private readonly ApplicationContext _context;

        public BasketController(ApplicationContext context)
        {
            _context = context;
        }

        public IActionResult Store(int productId)
        {
            var cart = new Cart();

            cart.DueDate = DateTime.Now + TimeSpan.FromDays(2);

            var cartItem = new CartItem();

            var product = _context.Products.Single();

            cartItem.Product = product;
            cartItem.Price = product.Price;
            cartItem.Quantity = 1;

            cart.Items.Add(cartItem);

            _context.Carts.Add(cart);

            _context.SaveChanges();

            return View(cart);
        }
    }
}
