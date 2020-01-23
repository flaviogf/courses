using Owin;

namespace OwinDemo.Pipeline
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseStaticFiles();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello, world.");
            });
        }
    }
}