using Microsoft.Owin.Security;
using System.Web.Mvc;

namespace ByteBank.Web.Controllers
{
    public class SignOutController : Controller
    {
        private readonly IAuthenticationManager _authenticationManager;

        public SignOutController(IAuthenticationManager authenticationManager)
        {
            _authenticationManager = authenticationManager;
        }

        public ActionResult Index()
        {
            _authenticationManager.SignOut();

            return RedirectToAction("Index", "Home");
        }
    }
}