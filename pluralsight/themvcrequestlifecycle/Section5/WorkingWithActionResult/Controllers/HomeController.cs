using System.Web.Mvc;
using WorkingWithActionResult.Models;
using WorkingWithActionResult.Results;

namespace WorkingWithActionResult.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var user = new User
            {
                Email = "someone@something.com",
                Phone = "+5516999999999"
            };

            return JsonNet(user);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        private ActionResult JsonNet(object data)
        {
            return new JsonNetResult(data);
        }
    }
}