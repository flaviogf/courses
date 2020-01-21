using System.Diagnostics;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

[assembly: PreApplicationStartMethod(typeof(PreApplicationStartMethod.MvcApplication), "Register")]

namespace PreApplicationStartMethod
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static void Register()
        {
            Trace.WriteLine("Registering");

            HttpApplication.RegisterModule(typeof(LoggerModule));
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
