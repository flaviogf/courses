using System.Threading.Tasks;
using CarvedRock.Web.Clients;
using Microsoft.AspNetCore.Mvc;

namespace CarvedRock.Web.Controllers
{
    [Route("")]
    [Route("home")]
    public class HomeController : Controller
    {
        private readonly ProductHttpClient _productHttpClient;

        public HomeController(ProductHttpClient productHttpClient)
        {
            _productHttpClient = productHttpClient;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _productHttpClient.GetAll();

            return View(products);
        }
    }
}
