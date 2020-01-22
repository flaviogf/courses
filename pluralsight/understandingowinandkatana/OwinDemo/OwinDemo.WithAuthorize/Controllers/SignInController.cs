using Microsoft.Owin.Security.Cookies;
using OwinDemo.WithAuthorize.ViewModels;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace OwinDemo.WithAuthorize.Controllers
{
    public class SignInController : Controller
    {
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Index(SignInViewModel viewModel)
        {
            if (viewModel.Username == "flaviogf" && viewModel.Password == "test123")
            {
                var context = Request.GetOwinContext();

                var claims = new[] { new Claim(ClaimTypes.Name, viewModel.Username) };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationType);

                context.Authentication.SignIn(identity);

                return RedirectToAction("Index", "Home");
            }

            return View(viewModel);
        }
    }
}