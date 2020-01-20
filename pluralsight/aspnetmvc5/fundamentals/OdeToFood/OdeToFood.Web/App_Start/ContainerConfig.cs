using Autofac;
using Autofac.Integration.Mvc;
using OdeToFood.Data.Services;
using System.Web.Mvc;

namespace OdeToFood.Web
{
    public class ContainerConfig
    {
        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<InMemoryRestaurantData>().As<IRestaurantData>().SingleInstance();

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}