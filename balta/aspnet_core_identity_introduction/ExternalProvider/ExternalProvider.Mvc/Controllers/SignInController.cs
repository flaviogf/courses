using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ExternalProvider.Mvc.Controllers
{
    public class SignInController : Controller
    {
        public async Task<IActionResult> Store()
        {
            return View();
        }
    }
}
