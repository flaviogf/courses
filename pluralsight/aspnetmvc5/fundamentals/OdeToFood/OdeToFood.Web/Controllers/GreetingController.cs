using OdeToFood.Web.Models;
using System.Configuration;
using System.Web.Mvc;

namespace OdeToFood.Web.Controllers
{
    public class GreetingController : Controller
    {
        public ActionResult Index(string name)
        {
            var message = ConfigurationManager.AppSettings["message"];

            var viewModel = new GreetingViewModel
            {
                Message = message,
                Name = name ?? "no name"
            };

            return View(viewModel);
        }
    }
}