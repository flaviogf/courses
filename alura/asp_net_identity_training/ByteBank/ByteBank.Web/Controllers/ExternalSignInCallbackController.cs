using ByteBank.Web.Infra;
using ByteBank.Web.Models;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ByteBank.Web.Controllers
{
    public class ExternalSignInCallbackController : Controller
    {
        private readonly IAuthenticationManager _authenticationManager;

        private readonly ApplicationSignInManager _signInManager;

        private readonly ApplicationUserManager _userManager;

        public ExternalSignInCallbackController(IAuthenticationManager authenticationManager, ApplicationSignInManager signInManager, ApplicationUserManager userManager)
        {
            _authenticationManager = authenticationManager;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<ActionResult> Index()
        {
            var info = await _authenticationManager.GetExternalLoginInfoAsync();

            if (info == null)
            {
                return RedirectToAction("Index", "SignIn");
            }

            var status = await _signInManager.ExternalSignInAsync(info, true);

            if (status == SignInStatus.Success)
            {
                return RedirectToAction("Index", "Home");
            }

            var user = new ApplicationUser
            {
                UserName = info.Email,
                Email = info.Email
            };

            var createResult = await _userManager.CreateAsync(user);

            if (!createResult.Succeeded)
            {
                return RedirectToAction("Index", "SignIn");
            }

            var loginResult = await _userManager.AddLoginAsync(user.Id, info.Login);

            if (!loginResult.Succeeded)
            {
                return RedirectToAction("Index", "SignIn");
            }

            await _signInManager.SignInAsync(user, true, true);

            return RedirectToAction("Index", "Home");
        }
    }
}