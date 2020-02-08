using ByteBank.Web.Infra;
using ByteBank.Web.ViewModels;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ByteBank.Web.Controllers
{
    public class EmailConfirmationController : Controller
    {
        private readonly ApplicationUserManager _userManager;

        public EmailConfirmationController(ApplicationUserManager userManager)
        {
            _userManager = userManager;
        }

        public async Task<ActionResult> Index(string userId, string token)
        {
            var result = await _userManager.ConfirmEmailAsync(userId, token);

            var viewModel = new EmailConfirmationViewModel();

            if (result.Succeeded)
            {
                viewModel.Message = "Your email have been confirmed.";
            }
            else
            {
                viewModel.Message = "Oops... Something went wrong.";
            }

            return View(viewModel);
        }
    }
}