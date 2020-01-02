using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WithoutIdentity.Mvc.Extensions;
using WithoutIdentity.Mvc.Models;
using WithoutIdentity.Mvc.ViewModels.SignUp;

namespace WithoutIdentity.Mvc.Controllers
{
    public class SignUpController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly SignInManager<ApplicationUser> _signInManager;

        public SignUpController
        (
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager
        )
        {
            _userManager = userManager;
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
        public async Task<IActionResult> Store(SignUpStoreViewModel viewModel)
        {
            var user = new ApplicationUser
            {
                UserName = viewModel.Email,
                Email = viewModel.Email
            };

            var result = await _userManager.CreateAsync(user, viewModel.Password);

            if (result.Succeeded)
            {

                return RedirectToAction("Show", "Home");
            }

            ModelState.AddErrors(result.Errors);

            return View(viewModel);
        }
    }
}
