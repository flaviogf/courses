using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(WiredBrain.Web.Startup))]

namespace WiredBrain.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}
