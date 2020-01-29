using System.Web.Mvc;

namespace Paladin.Web.Controllers
{
    public class FinalController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            Session.Clear();

            return View();
        }
    }
}