using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using TwoFactorAuthentication.Mvc.Models;

namespace TwoFactorAuthentication.Mvc.Controllers
{
    public class ExternalSignInController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;

        private readonly UserManager<ApplicationUser> _userManager;

        public ExternalSignInController
        (
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager
        )
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Store()
        {
            var info = await _signInManager.GetExternalLoginInfoAsync();

            var signInResult = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);

            if (signInResult.Succeeded)
            {
                return RedirectToAction("Edit", "Profile");
            }

            var email = info.Principal.FindFirstValue(ClaimTypes.Email);

            var user = new ApplicationUser
            {
                UserName = email,
                Email = email
            };

            await _userManager.CreateAsync(user);

            await _userManager.AddLoginAsync(user, info);

            await _signInManager.SignInAsync(user, isPersistent: false);

            return RedirectToAction("Edit", "Profile");
        }
    }
}
