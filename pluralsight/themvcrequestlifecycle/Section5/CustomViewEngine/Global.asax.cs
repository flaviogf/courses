using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CustomViewEngine
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ViewEngines.Engines.Add(new RazorViewEngine()
            {
                ViewLocationFormats = new string[] { "~/Templates/{1}/{0}.cshtml" },
                PartialViewLocationFormats = new string[] { "~/Templates/{1}/_{0}.cshtml" }
            });
        }
    }
}
