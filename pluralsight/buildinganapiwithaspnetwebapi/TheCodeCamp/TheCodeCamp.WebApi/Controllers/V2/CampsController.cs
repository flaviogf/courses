using AutoMapper;
using Microsoft.Web.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using TheCodeCamp.WebApi.Repositories;
using TheCodeCamp.WebApi.ViewModels;

namespace TheCodeCamp.WebApi.Controllers.V2
{
    [ApiVersion("2.0")]
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
        public async Task<IHttpActionResult> Get()
        {
            var camps = _mapper.Map<IEnumerable<CampViewModel>>(await _repository.GetAllCampsAsync());

            return Ok(new { Data = camps, Errors = Array.Empty<string>() });
        }
    }
}