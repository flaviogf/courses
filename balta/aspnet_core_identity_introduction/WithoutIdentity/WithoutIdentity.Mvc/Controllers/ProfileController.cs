using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WithoutIdentity.Mvc.Extensions;
using WithoutIdentity.Mvc.Models;
using WithoutIdentity.Mvc.ViewModels.Profile;

namespace WithoutIdentity.Mvc.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ProfileController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit()
        {
            var user = await _userManager.GetUserAsync(User);

            var viewModel = new ProfileEditViewModel
            {
                UserName = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber
            };

            return View(viewModel);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProfileEditViewModel viewModel)
        {
            var user = await _userManager.GetUserAsync(User);

            var errors = new List<IdentityError>();

            if (viewModel.Email != user.Email)
            {
                var result = await _userManager.SetEmailAsync(user, viewModel.Email);

                errors.AddRange(result.Errors);
            }

            if (viewModel.PhoneNumber != user.PhoneNumber)
            {
                var result = await _userManager.SetPhoneNumberAsync(user, viewModel.PhoneNumber);

                errors.AddRange(result.Errors);
            }

            if (!errors.Any())
            {
                return RedirectToAction(nameof(Edit));
            }

            ModelState.AddErrors(errors);

            return View(viewModel);
        }
    }
}

