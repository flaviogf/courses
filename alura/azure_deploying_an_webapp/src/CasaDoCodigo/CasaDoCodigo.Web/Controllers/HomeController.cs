using Microsoft.AspNetCore.Mvc;

namespace CasaDoCodigo.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
