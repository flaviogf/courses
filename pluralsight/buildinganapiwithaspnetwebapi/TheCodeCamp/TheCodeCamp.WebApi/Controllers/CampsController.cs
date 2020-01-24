using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using TheCodeCamp.WebApi.Repositories;
using TheCodeCamp.WebApi.ViewModels;

namespace TheCodeCamp.WebApi.Controllers
{
    [RoutePrefix("api/camps")]
    public class CampsController : ApiController
    {
        private readonly ICampRepository _repository;

        private readonly IMapper _mapper;

        public CampsController(ICampRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> Get(bool includeTalks = false)
        {
            var campsViewModel = _mapper.Map<IEnumerable<CampViewModel>>(await _repository.GetAllCampsAsync(includeTalks));

            return Ok(campsViewModel);
        }

        [HttpGet]
        [Route("{moniker}")]
        public async Task<IHttpActionResult> Get(string moniker, bool includeTalks = false)
        {
            var campViewModel = _mapper.Map<CampViewModel>(await _repository.GetCampAsync(moniker, includeTalks));

            if (campViewModel == null)
            {
                return NotFound();
            }

            return Ok(campViewModel);
        }

        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> Post(CampViewModel campViewModel)
        {
            return Ok(campViewModel);
        }
    }
}