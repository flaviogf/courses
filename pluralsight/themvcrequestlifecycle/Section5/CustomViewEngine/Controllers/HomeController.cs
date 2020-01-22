using CustomViewEngine.Models;
using System.Web.Mvc;

namespace CustomViewEngine.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var user = new User
            {
                Name = "Someone"
            };

            return View(user);
        }
    }
}