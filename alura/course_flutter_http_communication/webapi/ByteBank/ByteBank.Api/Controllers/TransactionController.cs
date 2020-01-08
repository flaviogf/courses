using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ByteBank.Api.Controllers
{
    [ApiController]
    [Route("/api/transaction")]
    public class TransactionController : ControllerBase
    {
        [HttpPost]
        [Route("")]
        [Authorize]
        public async Task<IActionResult> Store()
        {
            return Ok();
        }

        [HttpGet]
        [Route("")]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return Ok();
        }
    }
}
