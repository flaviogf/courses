using ByteBank.Web.Infra;
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

        public ActionResult Show()
        {
            return View();
        }
    }
}