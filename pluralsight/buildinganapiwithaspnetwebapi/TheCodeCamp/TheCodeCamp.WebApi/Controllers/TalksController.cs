using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using TheCodeCamp.WebApi.Repositories;
using TheCodeCamp.WebApi.ViewModels;

namespace TheCodeCamp.WebApi.Controllers
{
    [RoutePrefix("api/camps/{moniker}/talks")]
    public class TalksController : ApiController
    {
        private readonly ICampRepository _repository;

        private readonly IMapper _mapper;

        public TalksController(ICampRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> Get(string moniker, bool includeSpeaker = false)
        {
            var talksViewModel = _mapper.Map<IEnumerable<TalkViewModel>>(await _repository.GetTalksByMonikerAsync(moniker, includeSpeaker));

            return Ok(talksViewModel);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IHttpActionResult> Get(string moniker, int id, bool includeSpeaker = false)
        {
            var talkViewModel = _mapper.Map<TalkViewModel>(await _repository.GetTalkByMoniker(moniker, id, includeSpeaker));

            if (talkViewModel == null)
            {
                return NotFound();
            }

            return Ok(talkViewModel);
        }
    }
}