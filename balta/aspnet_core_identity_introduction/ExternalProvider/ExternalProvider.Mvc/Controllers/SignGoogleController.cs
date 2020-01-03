using ExternalProvider.Mvc.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ExternalProvider.Mvc.Controllers
{
    public class SignGoogleController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;

        public SignGoogleController(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Show()
        {
            var url = Url.Action("Store", "SignGoogle");

            var properties = _signInManager.ConfigureExternalAuthenticationProperties("Google", url);

            return Challenge(properties, "Google");
        }

        public async Task<IActionResult> Store()
        {
            var info = await _signInManager.GetExternalLoginInfoAsync();

            return RedirectToAction("Show", "Home");
        }
    }
}
