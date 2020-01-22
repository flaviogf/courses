using Microsoft.Owin;

namespace OwinDemo.Web.Middlewares
{
    public class OwinEventArgs
    {
        public OwinEventArgs(OwinContext context)
        {
            Context = context;
        }

        public OwinContext Context { get; }
    }
}