using ExternalProvider.Mvc.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ExternalProvider.Mvc.Controllers
{
    public class SignInGoogleController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;

        private readonly UserManager<ApplicationUser> _userManager;

        public SignInGoogleController
        (
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager
        )
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<IActionResult> Show()
        {
            var url = Url.Action("Store", "SignInGoogle");

            var properties = _signInManager.ConfigureExternalAuthenticationProperties("Google", url);

            return Challenge(properties, "Google");
        }

        public async Task<IActionResult> Store()
        {
            var info = await _signInManager.GetExternalLoginInfoAsync();

            var signInResult = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);

            if (signInResult.Succeeded)
            {
                return RedirectToAction("Show", "Home");
            }

            var email = info.Principal.FindFirstValue(ClaimTypes.Email);

            var user = new ApplicationUser
            {
                UserName = email,
                Email = email
            };

            var createResult = await _userManager.CreateAsync(user);

            if (!createResult.Succeeded)
            {
                return RedirectToAction("Store", "SignIn");
            }

            var loginResult = await _userManager.AddLoginAsync(user, info);

            if (!loginResult.Succeeded)
            {
                return RedirectToAction("Store", "SignIn");
            }

            foreach (var token in info.AuthenticationTokens)
            {
                await _userManager.SetAuthenticationTokenAsync(user, info.LoginProvider, token.Name, token.Value);
            }

            await _signInManager.SignInAsync(user, isPersistent: false);

            return RedirectToAction("Show", "Home");
        }
    }
}
