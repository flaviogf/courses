using ByteBank.Web.Infra;
using Microsoft.Owin.Security;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ByteBank.Web.Controllers
{
    public class ExternalSignInCallbackController : Controller
    {
        private readonly IAuthenticationManager _authenticationManager;

        private readonly ApplicationSignInManager _signInManager;

        public ExternalSignInCallbackController(IAuthenticationManager authenticationManager, ApplicationSignInManager signInManager)
        {
            _authenticationManager = authenticationManager;
            _signInManager = signInManager;
        }

        public async Task<ActionResult> Index()
        {
            var info = await _authenticationManager.GetExternalLoginInfoAsync();

            Debug.WriteLine(info.ExternalIdentity.FindFirst(info.ExternalIdentity.NameClaimType));

            return RedirectToAction("Index", "Home");
        }
    }
}