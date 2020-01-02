using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WithoutIdentity.Mvc.Extensions;
using WithoutIdentity.Mvc.Models;
using WithoutIdentity.Mvc.ViewModels.ChangePassword;

namespace WithoutIdentity.Mvc.Controllers
{
    public class ChangePasswordController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ChangePasswordController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ChangePasswordEditViewModel viewModel)
        {
            var user = await _userManager.GetUserAsync(User);

            var result = await _userManager.ChangePasswordAsync(user, viewModel.OldPassword, viewModel.NewPassword);

            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Edit));
            }

            ModelState.AddErrors(result.Errors);

            return View(viewModel);
        }
    }
}
