using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PrimitiveObsession.Core;
using PrimitiveObsession.UI.Models;

namespace PrimitiveObsession.UI.Controllers
{
    [Route("[controller]")]
    public class CustomerController : Controller
    {
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ILogger<CustomerController> logger)
        {
            _logger = logger;
        }

        [Route("Create")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Route("Create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm]CustomerModel model)
        {
            var name = Name.Create(model.Name);

            if (name.IsFaiulure)
            {
                ModelState.AddModelError(nameof(model.Name), name.Error);
                return View(model);
            }

            var email = Email.Create(model.Email);

            if (email.IsFaiulure)
            {
                ModelState.AddModelError(nameof(model.Email), email.Error);
                return View(model);
            }

            var customer = new Customer(name.Value, email.Value);

            _logger.LogInformation("Customer '{0}' have been created", customer.Name);

            return RedirectToAction("Create");
        }
    }
}