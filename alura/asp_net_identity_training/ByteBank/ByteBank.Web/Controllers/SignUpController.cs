using ByteBank.Web.Models;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;

namespace ByteBank.Web.Controllers
{
    public class SignUpController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public SignUpController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public ActionResult Show()
        {
            return View();
        }
    }
}