using CursoAspNetMvc5Alura.Web.App_Start;
using System.Web.Mvc;
using System.Web.Routing;

namespace CursoAspNetMvc5Alura.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            SimpleInjectorConfig.Inicializa();
            AutoMapperConfig.Inicializa();
        }
    }
}
