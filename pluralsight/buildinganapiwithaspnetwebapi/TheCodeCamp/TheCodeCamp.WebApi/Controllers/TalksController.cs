using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using TheCodeCamp.WebApi.Models;
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
        [Route("{id}", Name = "GetTalk")]
        public async Task<IHttpActionResult> Get(string moniker, int id, bool includeSpeaker = false)
        {
            var talkViewModel = _mapper.Map<TalkViewModel>(await _repository.GetTalkByMonikerAsync(moniker, id, includeSpeaker));

            if (talkViewModel == null)
            {
                return NotFound();
            }

            return Ok(talkViewModel);
        }

        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> Post(string moniker, TalkViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var camp = await _repository.GetCampAsync(moniker);

            var speaker = await _repository.GetSpeakerAsync(viewModel.Speaker.Id);

            var talk = _mapper.Map<Talk>(viewModel);

            talk.Camp = camp;

            talk.Speaker = speaker;

            await _repository.AddTalkAsync(talk);

            await _repository.SaveChangesAsync();

            var createdTalkViewModel = _mapper.Map<TalkViewModel>(talk);

            return CreatedAtRoute("GetTalk", new { moniker = camp.Moniker, id = createdTalkViewModel.Id }, createdTalkViewModel);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IHttpActionResult> Put(string moniker, int id, TalkViewModel viewModel)
        {
            var talk = await _repository.GetTalkByMonikerAsync(moniker, id, includeSpeaker: true);

            if (talk == null)
            {
                return NotFound();
            }

            _mapper.Map(viewModel, talk);

            if (viewModel.Speaker != null)
            {
                var speaker = await _repository.GetSpeakerAsync(viewModel.Speaker.Id);

                talk.Speaker = speaker;
            }

            await _repository.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IHttpActionResult> Delete(string moniker, int id)
        {
            var talk = await _repository.GetTalkByMonikerAsync(moniker, id);

            if (talk == null)
            {
                return NotFound();
            }

            await _repository.DeleteTalkAsync(talk);

            await _repository.SaveChangesAsync();

            return Ok();
        }
    }
}