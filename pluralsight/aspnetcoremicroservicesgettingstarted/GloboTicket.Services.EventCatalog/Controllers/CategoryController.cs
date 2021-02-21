using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using GloboTicket.Services.EventCatalog.Models;
using GloboTicket.Services.EventCatalog.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GloboTicket.Services.EventCatalog.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoryController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAll()
        {
            var categories = await _categoryRepository.GetAll();

            return Ok(_mapper.Map<IEnumerable<CategoryDto>>(categories));
        }
    }
}
