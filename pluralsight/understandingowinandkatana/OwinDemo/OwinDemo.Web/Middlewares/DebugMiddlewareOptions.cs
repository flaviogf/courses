using Microsoft.Owin;
using System;

namespace OwinDemo.Web.Middlewares
{
    public class DebugMiddlewareOptions
    {
        public event EventHandler<OwinEventArgs> IncomingRequest;

        public event EventHandler<OwinEventArgs> OutgoingRequest;

        public void OnIncomingRequest(object sender, OwinContext context)
        {
            IncomingRequest?.Invoke(sender, new OwinEventArgs(context));
        }

        public void OnOutgoingRequest(object sender, OwinContext context)
        {
            OutgoingRequest?.Invoke(sender, new OwinEventArgs(context));
        }
    }
}