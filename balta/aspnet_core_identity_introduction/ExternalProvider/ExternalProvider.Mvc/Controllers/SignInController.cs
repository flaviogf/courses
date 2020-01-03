using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ExternalProvider.Mvc.Controllers
{
    public class SignInController : Controller
    {

        public async Task<IActionResult> Store()
        {
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            return View();
        }
    }
}
