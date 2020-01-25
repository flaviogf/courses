using System.Configuration;
using System.Web.Http;

namespace TheCodeCamp.WebApi.Controllers
{
    [RoutePrefix("api/refresh-app-settings")]
    public class RefreshAppSettingsController : ApiController
    {
        [HttpOptions]
        [Route("")]
        public IHttpActionResult Options()
        {
            ConfigurationManager.RefreshSection("AppSettings");

            return Ok();
        }
    }
}