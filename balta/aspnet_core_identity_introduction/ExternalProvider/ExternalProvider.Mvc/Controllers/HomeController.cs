using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ExternalProvider.Mvc.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Show()
        {
            return View();
        }
    }
}
