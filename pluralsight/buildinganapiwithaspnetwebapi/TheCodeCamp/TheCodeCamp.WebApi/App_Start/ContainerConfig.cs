using Autofac;
using Autofac.Integration.WebApi;
using System.Reflection;
using System.Web.Http;

namespace TheCodeCamp.WebApi
{
    public class ContainerConfig
    {
        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<TheCodeCampContext>().InstancePerRequest();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            var container = builder.Build();

            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}