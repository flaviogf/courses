using Autofac;
using Autofac.Integration.Mvc;
using ByteBank.Web.Infra;
using ByteBank.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Owin;
using System.Web.Mvc;

[assembly: OwinStartup(typeof(ByteBank.Web.Startup))]

namespace ByteBank.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<ByteBankDbContext>().AsSelf().InstancePerRequest();

            builder.RegisterType<ApplicationUserStore>().As<IUserStore<ApplicationUser>>().InstancePerRequest();

            builder.RegisterType<ApplicationUser>().AsSelf().InstancePerRequest();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(builder.Build()));
        }
    }
}