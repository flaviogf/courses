using OdeToFood.Web.Models;
using System.Configuration;
using System.Web.Mvc;

namespace OdeToFood.Web.Controllers
{
    public class GreetingController : Controller
    {
        public ActionResult Index()
        {
            var message = ConfigurationManager.AppSettings["message"];

            var viewModel = new GreetingViewModel
            {
                Message = message
            };

            return View(viewModel);
        }
    }
}