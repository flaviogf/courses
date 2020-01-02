using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
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

            return View(viewModel);
        }
    }
}
