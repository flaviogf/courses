using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TwoFactorAuthentication.Mvc.Models;
using TwoFactorAuthentication.Mvc.ViewModels.Profile;

namespace TwoFactorAuthentication.Mvc.Controllers
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

            var issuer = "2FA";

            var secret = await _userManager.GetAuthenticatorKeyAsync(user);

            if (secret == null)
            {
                await _userManager.ResetAuthenticatorKeyAsync(user);

                secret = await _userManager.GetAuthenticatorKeyAsync(user);
            }

            var key = $"otpauth://totp/{issuer}:{user.UserName}?secret={secret}&issuer={issuer}&digits=6";

            var viewModel = new ProfileEditViewModel
            {
                UserName = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Key = key
            };

            return View(viewModel);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProfileEditViewModel viewModel)
        {
            var user = await _userManager.GetUserAsync(User);

            await _userManager.SetEmailAsync(user, viewModel.Email);

            await _userManager.SetPhoneNumberAsync(user, viewModel.PhoneNumber);

            return RedirectToAction("Edit");
        }
    }
}
