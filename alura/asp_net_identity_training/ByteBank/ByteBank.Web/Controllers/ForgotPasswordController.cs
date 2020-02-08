using ByteBank.Web.Infra;
using ByteBank.Web.ViewModels;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ByteBank.Web.Controllers
{
    public class ForgotPasswordController : Controller
    {
        private readonly ApplicationUserManager _userManager;

        public ForgotPasswordController(ApplicationUserManager userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(ForgotPasswordViewModel viewModel)
        {
            var user = await _userManager.FindByEmailAsync(viewModel.Email);

            if (user != null)
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user.Id);

                var link = Url.Action("Index", "RecoveryPassword", new { userId = user.Id, token }, Request.Url.Scheme);

                await _userManager.SendEmailAsync(user.Id, "Forgot Password", $"To recover your password clicks in the link bellow.\nLink: {link}");
            }

            return RedirectToAction("Index", "Home");
        }
    }
}