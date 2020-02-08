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

        private readonly ApplicationUserManager _userManager;

        public SignInController(ApplicationSignInManager signInManager, ApplicationUserManager userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(SignInViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var result = await _signInManager.PasswordSignInAsync(viewModel.UserName, viewModel.Password, isPersistent: true, shouldLockout: true);

            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToAction("Index", "Home");
                case SignInStatus.LockedOut:
                    var user = await _userManager.FindByNameAsync(viewModel.UserName);

                    if (user != null && await _userManager.CheckPasswordAsync(user, viewModel.Password))
                    {
                        ModelState.AddModelError(string.Empty, "Your account is blocked.");
                    }

                    return View(viewModel);
                default:
                    return View(viewModel);
            }
        }
    }
}