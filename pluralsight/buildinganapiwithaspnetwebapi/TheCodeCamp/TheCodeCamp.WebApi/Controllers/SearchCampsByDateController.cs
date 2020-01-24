using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using TheCodeCamp.WebApi.Repositories;
using TheCodeCamp.WebApi.ViewModels;

namespace TheCodeCamp.WebApi.Controllers
{
    [RoutePrefix("api/camps/searchByDate/{eventDate:datetime}")]
    public class SearchCampsByDateController : ApiController
    {
        private readonly ICampRepository _repository;

        private readonly IMapper _mapper;

        public SearchCampsByDateController(ICampRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [Route("")]
        public async Task<IHttpActionResult> Get(DateTime eventDate, bool includeTalks = false)
        {
            var campsViewModel = _mapper.Map<IEnumerable<CampViewModel>>(await _repository.GetAllCampsByEventDateAsync(eventDate, includeTalks));

            return Ok(campsViewModel);
        }
    }
}