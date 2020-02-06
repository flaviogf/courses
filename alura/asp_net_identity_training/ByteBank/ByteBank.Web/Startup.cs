using Autofac;
using Autofac.Integration.Mvc;
using ByteBank.Web.Infra;
using ByteBank.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataProtection;
using Owin;
using System.Web;
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

            builder.Register<IAuthenticationManager>((c) => HttpContext.Current.GetOwinContext().Authentication);

            builder.Register<IDataProtectionProvider>((c) => app.GetDataProtectionProvider());

            builder.RegisterType<ApplicationUserStore>().As<IUserStore<ApplicationUser>>().InstancePerRequest();

            builder.RegisterType<ApplicationUserManager>().AsSelf().InstancePerRequest();

            builder.RegisterType<ApplicationSignInManager>().AsSelf().InstancePerRequest();

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}