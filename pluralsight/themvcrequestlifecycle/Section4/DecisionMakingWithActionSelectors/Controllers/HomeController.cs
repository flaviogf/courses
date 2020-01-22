using DecisionMakingWithActionSelectors.Attributes;
using System.Web.Mvc;

namespace DecisionMakingWithActionSelectors.Controllers
{
    public class HomeController : Controller
    {
        [Admin]
        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Register(string username)
        {
            return View();
        }
    }
}