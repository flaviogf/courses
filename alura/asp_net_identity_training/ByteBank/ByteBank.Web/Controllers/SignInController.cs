using ByteBank.Web.ViewModels;
using System.Web.Mvc;

namespace ByteBank.Web.Controllers
{
    public class SignInController : Controller
    {
        [HttpGet]
        public ActionResult Show()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Show(SignInShowViewModel viewModel)
        {
            return View(viewModel);
        }
    }
}