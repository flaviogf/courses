using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BookCovers.Api.Controllers
{
    [ApiController]
    [Route("api/bookcovers")]
    public class BookCoversController : ControllerBase
    {
        [HttpGet("{name}")]
        public async Task<IActionResult> GetBookCover(string name, bool returnFault = false)
        {
            if (returnFault)
            {
                await Task.Delay(500);

                return new StatusCodeResult(500);
            }

            var random = new Random();

            var fakeCoverBytes = random.Next(2097152, 10485760);

            var fakeCover = new byte[fakeCoverBytes];

            random.NextBytes(fakeCover);

            return Ok(new { Name = name, Content = fakeCover });
        }
    }
}
