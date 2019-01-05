using Microsoft.AspNetCore.Mvc;

namespace CursoCoreAlura.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
