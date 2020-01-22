using FilterExecutingOrder.Filters;
using System.Web.Mvc;

namespace FilterExecutingOrder.Controllers
{
    [TwiceFilter]
    public class HomeController : Controller
    {
        [FirstFilter]
        [CustomAuthorize]
        public ActionResult Index()
        {
            return View();
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
    }
}