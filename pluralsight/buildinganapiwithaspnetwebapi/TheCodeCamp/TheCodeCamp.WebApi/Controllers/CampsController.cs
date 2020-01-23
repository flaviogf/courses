using System.Threading.Tasks;
using System.Web.Http;
using TheCodeCamp.WebApi.Data;

namespace TheCodeCamp.WebApi.Controllers
{
    public class CampsController : ApiController
    {
        private readonly ICampRepository _repository;

        public CampsController(ICampRepository repository)
        {
            _repository = repository;
        }

        public async Task<IHttpActionResult> Get()
        {
            var camps = await _repository.GetAllCampsAsync();

            return Ok(camps);
        }
    }
}