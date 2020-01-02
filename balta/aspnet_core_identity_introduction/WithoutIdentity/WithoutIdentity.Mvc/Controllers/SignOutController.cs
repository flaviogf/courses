using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WithoutIdentity.Mvc.Models;

namespace WithoutIdentity.Mvc.Controllers
{
    public class SignOutController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;

        public SignOutController(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Store()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Store", "SignIn");
        }
    }
}
