using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WithoutIdentity.Mvc.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Show()
        {
            return View();
        }
    }
}
