using Owin;
using OwinDemo.Web.Middlewares;
using System.Diagnostics;

namespace OwinDemo.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseDebug(options =>
            {
                var stopwatch = new Stopwatch();

                options.IncomingRequest += (sender, args) =>
                {
                    stopwatch.Start();

                    Debug.WriteLine($"Incoming request for {args.Context.Request.Uri.AbsolutePath}", "INFO");
                };

                options.OutgoingRequest += (sender, args) =>
                {
                    Debug.WriteLine($"Outgoing request for {args.Context.Request.Uri.AbsolutePath}", "INFO");

                    stopwatch.Stop();

                    Debug.WriteLine($"It has passed {stopwatch.ElapsedMilliseconds} ms", "INFO");

                    stopwatch.Restart();
                };
            });

            app.Use(async (ctx, next) =>
            {
                ctx.Response.ContentType = "text/plain";
                await ctx.Response.WriteAsync("Hello, world.");
            });
        }
    }
}