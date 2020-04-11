using Microsoft.AspNetCore.Mvc;
using PSStore.Application.Customers.Queries.GetCustomerList;

namespace PSStore.Presentation.Controllers
{
    [Route("[controller]")]
    public class CustomerController: Controller
    {
        private readonly IGetCustomerListQuery _getCustomerListQuery;

        public CustomerController(IGetCustomerListQuery getCustomerListQuery)
        {
            _getCustomerListQuery = getCustomerListQuery;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            var customers = _getCustomerListQuery.Execute();

            return View(customers);
        }
    }
}
