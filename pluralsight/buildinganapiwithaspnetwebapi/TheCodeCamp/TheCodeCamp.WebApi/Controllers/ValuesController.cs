using System.Web.Http;

namespace TheCodeCamp.WebApi.Controllers
{
    public class ValuesController : ApiController
    {
        public string[] Get()
        {
            return new string[] { "Hello", "World" };
        }
    }
}