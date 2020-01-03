using AspNet.Security.OAuth.GitHub;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TwoFactorAuthentication.Mvc.Models;

namespace TwoFactorAuthentication.Mvc.Controllers
{
    public class GitHubController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;

        public GitHubController(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Store()
        {
            var info = _signInManager.GetExternalLoginInfoAsync();

            return RedirectToAction("Store", "SignIn");
        }

        public async Task<IActionResult> Show()
        {
            var url = Url.Action("Store", "GitHub");

            var properties = _signInManager.ConfigureExternalAuthenticationProperties(GitHubAuthenticationDefaults.AuthenticationScheme, url);

            return Challenge(properties, GitHubAuthenticationDefaults.AuthenticationScheme);
        }
    }
}
