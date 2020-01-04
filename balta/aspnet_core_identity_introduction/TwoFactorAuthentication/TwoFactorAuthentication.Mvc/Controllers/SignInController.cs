using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace TwoFactorAuthentication.Mvc.Controllers
{
    public class SignInController : Controller
    {
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Store()
        {
            return View();
        }
    }
}

