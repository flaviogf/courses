using ByteBank.Web.Infra;
using ByteBank.Web.ViewModels;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ByteBank.Web.Controllers
{
    public class RecoveryPasswordController : Controller
    {
        private readonly ApplicationUserManager _userManager;

        public RecoveryPasswordController(ApplicationUserManager userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public ActionResult Index(string userId, string token)
        {
            var viewModel = new RecoveryPasswordViewModel
            {
                UserId = userId,
                Token = token
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(RecoveryPasswordViewModel viewModel)
        {
            var result = await _userManager.ResetPasswordAsync(viewModel.UserId, viewModel.Token, viewModel.Password);

            if (!result.Succeeded)
            {
                return View(viewModel);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}