using System.Linq;
using CasaDoCodigo.Web.Infrastrucutre;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Index()
        {
            var products = _context.Products.ToList();

            return View(products);
        }
    }
}
