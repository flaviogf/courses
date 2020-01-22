using Owin;
using System.Web.Http;

namespace OwinDemo.Hosting
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var configuration = new HttpConfiguration();

            configuration.MapHttpAttributeRoutes();

            app.UseWebApi(configuration);
        }
    }
}
