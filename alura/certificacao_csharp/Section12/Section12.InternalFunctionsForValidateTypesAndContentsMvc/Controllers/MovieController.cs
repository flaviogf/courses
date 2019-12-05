using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Section12.InternalFunctionsForValidateTypesAndContentsMvc.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Section12.InternalFunctionsForValidateTypesAndContentsMvc.Controllers
{
    [ApiController]
    [Route("movie")]
    public class MovieController : Controller
    {
        private readonly ApplicationContext _context;

        public MovieController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Store([FromBody]Movie movie)
        {
            await _context.AddAsync(movie);

            await _context.SaveChangesAsync();

            var uri = $"movie/{movie.Id}";

            return Created(uri, movie);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Show([FromRoute]int id)
        {
            var movie = await (from current in _context.Movies
                               where current.Id == id
                               select current).FirstAsync();

            return Ok(movie);
        }
    }
}
