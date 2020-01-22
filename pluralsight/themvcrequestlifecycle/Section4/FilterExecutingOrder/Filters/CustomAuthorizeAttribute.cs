using System.Web;
using System.Web.Mvc;

namespace FilterExecutingOrder.Filters
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            HttpContext.Current.Application["order"] = "<li>Authorize</li>";
        }
    }
}