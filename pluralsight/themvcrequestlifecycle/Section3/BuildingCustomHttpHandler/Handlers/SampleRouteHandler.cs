using System.Web;
using System.Web.Routing;

namespace BuildingCustomHttpHandler.Handlers
{
    public class SampleRouteHandler : IRouteHandler
    {
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return new SampleHttpHandler();
        }
    }
}