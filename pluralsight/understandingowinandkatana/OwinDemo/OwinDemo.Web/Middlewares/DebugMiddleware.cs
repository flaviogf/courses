using Microsoft.Owin;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppFunc = System.Func<System.Collections.Generic.IDictionary<string, object>, System.Threading.Tasks.Task>;

namespace OwinDemo.Web.Middlewares
{
    public class DebugMiddleware
    {
        private readonly DebugMiddlewareOptions _options;

        private readonly AppFunc _next;

        public DebugMiddleware(AppFunc next)
        {
            _next = next;
        }

        public DebugMiddleware(AppFunc next, DebugMiddlewareOptions options) : this(next)
        {
            _options = options;
        }

        public async Task Invoke(IDictionary<string, object> environment)
        {
            var context = new OwinContext(environment);
            _options?.OnIncomingRequest(this, context);
            await _next(environment);
            _options?.OnOutgoingRequest(this, context);
        }
    }
}