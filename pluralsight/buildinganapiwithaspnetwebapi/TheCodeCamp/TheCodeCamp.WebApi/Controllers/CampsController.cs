using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using TheCodeCamp.WebApi.Models;
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
        [Route("{moniker}", Name = "GetCamp")]
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
            if (await _repository.ExistsCampAsync(campViewModel.Moniker))
            {
                ModelState.AddModelError("campViewModel.Moniker", "The moniker is already is use, please choose a new one.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var camp = _mapper.Map<Camp>(campViewModel);

            await _repository.AddCampAsync(camp);

            await _repository.SaveChangesAsync();

            var createdCampViewModel = _mapper.Map<CampViewModel>(camp);

            return CreatedAtRoute("GetCamp", new { moniker = createdCampViewModel.Moniker }, createdCampViewModel);
        }

        [HttpPut]
        [Route("{moniker}")]
        public async Task<IHttpActionResult> Put(string moniker, CampViewModel campViewModel)
        {
            var camp = await _repository.GetCampAsync(moniker);

            if (camp == null)
            {
                return NotFound();
            }

            _mapper.Map(campViewModel, camp);

            await _repository.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete]
        [Route("{moniker}")]
        public async Task<IHttpActionResult> Delete(string moniker)
        {
            var camp = await _repository.GetCampAsync(moniker);

            if (camp == null)
            {
                return NotFound();
            }

            await _repository.DeleteCampAsync(camp);


            await _repository.SaveChangesAsync();

            return Ok();
        }
    }
}