using Autofac;
using Autofac.Integration.Mvc;
using AutoMapper;
using ByteBank.Web.Infra;
using ByteBank.Web.Models;
using ByteBank.Web.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.DataProtection;
using Microsoft.Owin.Security.Google;
using Owin;
using System.Configuration;
using System.Web;
using System.Web.Mvc;

[assembly: OwinStartup(typeof(ByteBank.Web.Startup))]

namespace ByteBank.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var configuration = new MapperConfiguration(it =>
            {
                it.CreateMap<ApplicationUser, UserViewModel>();
            });

            var mapper = configuration.CreateMapper();

            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<ByteBankDbContext>().AsSelf().InstancePerRequest();

            builder.Register<IAuthenticationManager>((c) => HttpContext.Current.GetOwinContext().Authentication);

            builder.Register<IDataProtectionProvider>((c) => app.GetDataProtectionProvider());

            builder.RegisterType<ApplicationUserStore>().As<IUserStore<ApplicationUser>>().InstancePerRequest();

            builder.RegisterType<ApplicationUserManager>().AsSelf().InstancePerRequest();

            builder.RegisterType<ApplicationSignInManager>().AsSelf().InstancePerRequest();

            builder.RegisterInstance<IMapper>(mapper);

            var container = builder.Build();

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie
            });

            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions
            {
                ClientId = ConfigurationManager.AppSettings["Google:ClientId"],
                ClientSecret = ConfigurationManager.AppSettings["Google:ClientSecret"],
                Caption = "Byte Bank",
                CallbackPath = new PathString("/signin-google")
            });

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}