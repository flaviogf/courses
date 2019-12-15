using CasaDoCodigo.Web.Database;
using CasaDoCodigo.Web.ViewModels.Catalog;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
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

        public async Task<IActionResult> Index()
        {
            var products = await (from product in _context.Products
                                  orderby product.Name
                                  select product).ToListAsync();

            var viewModel = new IndexCatalogViewModel
            {
                Products = products
            };

            return View(viewModel);
        }
    }
}
