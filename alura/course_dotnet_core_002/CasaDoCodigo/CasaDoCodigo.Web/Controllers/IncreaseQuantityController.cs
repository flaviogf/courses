﻿using CasaDoCodigo.Web.Database;
using CasaDoCodigo.Web.Lib;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Web.Controllers
{
    public class IncreaseQuantityController : Controller
    {
        private readonly ApplicationContext _context;

        private readonly IShoppingCart _shoppingCart;

        public IncreaseQuantityController(ApplicationContext context, IShoppingCart shoppingCart)
        {
            _context = context;
            _shoppingCart = shoppingCart;
        }

        public async Task<IActionResult> Store(int id)
        {
            var product = await (from current in _context.Products
                                 where current.Id == id
                                 select current).FirstAsync();

            await _shoppingCart.Add(product);

            return RedirectToAction("Index", "ShoppingCart");
        }
    }
}
