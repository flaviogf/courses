using Paladin.Web.ViewModels;
using System.Web.Mvc;

namespace Paladin.Web.Controllers
{
    public class EmploymentController : Controller
    {
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmploymentsViewModel viewModel)
        {
            return RedirectToAction("Create");
        }
    }
}