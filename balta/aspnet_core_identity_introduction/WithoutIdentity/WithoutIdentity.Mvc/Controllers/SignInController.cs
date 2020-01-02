using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WithoutIdentity.Mvc.Models;
using WithoutIdentity.Mvc.ViewModels.SignIn;

namespace WithoutIdentity.Mvc.Controllers
{
    public class SignInController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;

        public SignInController
        (
            SignInManager<ApplicationUser> signInManager
        )
        {
            _signInManager = signInManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Store()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Store(SignInStoreViewModel viewModel)
        {
            var result = await _signInManager.PasswordSignInAsync
            (
                viewModel.Email,
                viewModel.Password,
                isPersistent: viewModel.Remember,
                lockoutOnFailure: false
            );

            if (result.Succeeded)
            {
                return RedirectToAction("Show", "Home");
            }

            if (result.IsNotAllowed)
            {
                ModelState.AddModelError(string.Empty, "Invalid email or password.");
            }

            return View(viewModel);
        }
    }
}
