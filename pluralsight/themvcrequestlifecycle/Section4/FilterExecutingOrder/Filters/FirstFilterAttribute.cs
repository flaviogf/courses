using System.Web;
using System.Web.Mvc;

namespace FilterExecutingOrder.Filters
{
    public class FirstFilterAttribute : FilterAttribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContext.Current.Application["order"] += "<li>1º</li>";
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            HttpContext.Current.Application["order"] += "<li>1º</li>";
        }
    }
}