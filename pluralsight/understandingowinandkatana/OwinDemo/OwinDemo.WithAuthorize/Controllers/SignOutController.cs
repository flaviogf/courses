using Microsoft.Owin.Security.Cookies;
using System.Web;
using System.Web.Mvc;

namespace OwinDemo.WithAuthorize.Controllers
{
    public class SignOutController : Controller
    {
        public ActionResult Index()
        {
            var context = Request.GetOwinContext();

            context.Authentication.SignOut(CookieAuthenticationDefaults.AuthenticationType);

            return RedirectToAction("Index", "SignIn");
        }
    }
}