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

        [Route("")]
        public async Task<IHttpActionResult> Get()
        {
            var camps = _mapper.Map<IEnumerable<CampViewModel>>(await _repository.GetAllCampsAsync());

            return Ok(camps);
        }

        [Route("{moniker}")]
        public async Task<IHttpActionResult> Get(string moniker)
        {
            var camp = _mapper.Map<CampViewModel>(await _repository.GetCampAsync(moniker));

            if (camp == null)
            {
                return NotFound();
            }

            return Ok(camp);
        }
    }
}