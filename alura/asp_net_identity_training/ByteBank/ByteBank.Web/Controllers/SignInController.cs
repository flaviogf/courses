using ByteBank.Web.Infra;
using ByteBank.Web.ViewModels;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ByteBank.Web.Controllers
{
    public class SignInController : Controller
    {
        private readonly ApplicationSignInManager _signInManager;

        public SignInController(ApplicationSignInManager signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpGet]
        public ActionResult Show()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Show(SignInShowViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var result = await _signInManager.PasswordSignInAsync(viewModel.UserName, viewModel.Password, isPersistent: true, shouldLockout: false);

            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToAction("Index", "Home");
                default:
                    return View(viewModel);
            }
        }
    }
}