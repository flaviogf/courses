using ByteBank.Web.Infra;
using Microsoft.Owin.Security;
using System.Web.Mvc;

namespace ByteBank.Web.Controllers
{
    public class ExternalSignInController : Controller
    {
        private readonly ApplicationSignInManager _signInManager;

        public ExternalSignInController(ApplicationSignInManager signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string provider)
        {
            var properties = new AuthenticationProperties
            {
                RedirectUri = Url.Action("Index", "ExternalSignInCallback")
            };

            _signInManager.AuthenticationManager.Challenge(properties, provider);

            return new HttpUnauthorizedResult();
        }
    }
}