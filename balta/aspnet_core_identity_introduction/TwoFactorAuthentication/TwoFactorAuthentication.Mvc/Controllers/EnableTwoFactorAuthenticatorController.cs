using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TwoFactorAuthentication.Mvc.Models;
using TwoFactorAuthentication.Mvc.ViewModels.EnableTwoFactorAuthenticator;

namespace TwoFactorAuthentication.Mvc.Controllers
{
    public class EnableTwoFactorAuthenticatorController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public EnableTwoFactorAuthenticatorController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Store()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Store(EnableTwoFactorAuthenticatorStoreViewModel viewModel)
        {
            var user = await _userManager.GetUserAsync(User);

            var valid = await _userManager.VerifyTwoFactorTokenAsync(user, _userManager.Options.Tokens.AuthenticatorTokenProvider, viewModel.Code);

            if (!valid)
            {
                ModelState.AddModelError(string.Empty, "This code isn't valid, please verify your code and try again.");

                return View(viewModel);
            }

            await _userManager.SetTwoFactorEnabledAsync(user, enabled: true);

            return RedirectToAction("Edit", "Profile");
        }
    }
}
