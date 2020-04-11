using Microsoft.AspNetCore.Mvc;
using PSStore.Application.Products.Queries.GetProductList;

namespace PSStore.Presentation.Controllers
{
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly IGetProductListQuery _getProductListQuery;

        public ProductController(IGetProductListQuery getProductListQuery)
        {
            _getProductListQuery = getProductListQuery;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            var products = _getProductListQuery.Execute();

            return View(products);
        }
    }
}
