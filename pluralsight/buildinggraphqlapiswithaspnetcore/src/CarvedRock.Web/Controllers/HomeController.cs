using System.Threading.Tasks;
using CarvedRock.Web.Clients;
using Microsoft.AspNetCore.Mvc;

namespace CarvedRock.Web.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        private readonly ProductHttpClient _productHttpClient;

        private readonly ProductGraphQLClient _productGraphQLCLient;

        public HomeController(ProductHttpClient productHttpClient, ProductGraphQLClient productGraphQLClient)
        {
            _productHttpClient = productHttpClient;
            _productGraphQLCLient = productGraphQLClient;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _productHttpClient.GetAll();

            return View(products);
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> Detail(int productId)
        {
            var product = await _productGraphQLCLient.Get(productId);

            return View(product);
        }
    }
}
