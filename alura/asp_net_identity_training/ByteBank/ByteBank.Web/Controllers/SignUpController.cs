using ByteBank.Web.Infra;
using ByteBank.Web.Models;
using ByteBank.Web.ViewModels;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ByteBank.Web.Controllers
{
    public class SignUpController : Controller
    {
        private readonly ApplicationUserManager _userManager;

        public SignUpController(ApplicationUserManager userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public ActionResult Show()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Show(SignUpShowViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var user = new ApplicationUser
            {
                UserName = viewModel.UserName,
                Email = viewModel.Email
            };

            var result = await _userManager.CreateAsync(user, viewModel.Password);

            if (result.Succeeded)
            {
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user.Id);

                var userId = user.Id;

                var link = Url.Action("Show", "EmailConfirmation", new { userId, token }, Request.Url.Scheme);

                var message = $"Hello for confirm your email click on link bellow\nLink: {link}";

                await _userManager.SendEmailAsync(user.Id, "Confirm your email", message);

                return RedirectToAction("Index", "Home");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error);
            }

            return View(viewModel);
        }
    }
}