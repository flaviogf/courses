using CasaDoCodigo.Web.Database;
using CasaDoCodigo.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CasaDoCodigo.Web.Controllers
{
    public class CatalogController : Controller
    {
        private readonly ApplicationContext _context;

        public CatalogController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _context.Products.ToListAsync();

            var viewModel = new CatalogViewModel
            {
                Products = products
            };

            return View(viewModel);
        }
    }
}
