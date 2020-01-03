using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace TwoFactorAuthentication.Mvc.Controllers
{
    public class SignInController : Controller
    {
        public async Task<IActionResult> Store()
        {
            return View();
        }
    }
}

