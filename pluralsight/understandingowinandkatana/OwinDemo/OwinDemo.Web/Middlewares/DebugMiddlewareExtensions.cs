using Owin;
using System;

namespace OwinDemo.Web.Middlewares
{
    public static class DebugMiddlewareExtensions
    {
        public static IAppBuilder UseDebugMiddleware(this IAppBuilder target, Action<DebugMiddlewareOptions> configure)
        {
            var options = new DebugMiddlewareOptions();

            configure(options);

            return target.Use<DebugMiddleware>(options);
        }

        public static IAppBuilder UseDebugMiddleware(this IAppBuilder target)
        {
            return target.Use<DebugMiddleware>();
        }
    }
}