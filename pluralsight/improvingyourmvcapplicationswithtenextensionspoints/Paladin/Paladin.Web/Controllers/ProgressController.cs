using System.Web.Mvc;

namespace Paladin.Web.Controllers
{
    public class ProgressController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return PartialView();
        }
    }
}