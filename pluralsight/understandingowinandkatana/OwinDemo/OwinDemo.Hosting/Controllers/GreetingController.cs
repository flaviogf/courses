using System.Web.Http;

namespace OwinDemo.Hosting.Controllers
{
    [RoutePrefix("greeting")]
    public class GreetingController : ApiController
    {
        [HttpGet]
        [Route("")]
        public IHttpActionResult Get()
        {
            return Json("Hello, world");
        }
    }
}
