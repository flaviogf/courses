using ByteBank.Api.Models;
using ByteBank.Api.ViewModels.SignUp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ByteBank.Api.Controllers
{
    [ApiController]
    [Route("/api/signup")]
    public class SignUpController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public SignUpController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        [Route("")]
        [AllowAnonymous]
        public async Task<IActionResult> Store([FromBody]StoreSignUpViewModel viewModel)
        {
            var user = new ApplicationUser
            {
                UserName = viewModel.Email,
                Email = viewModel.Email
            };

            var result = await _userManager.CreateAsync(user, viewModel.Password);

            if (result.Succeeded)
            {
                return Ok();
            }

            return BadRequest(result.Errors);
        }
    }
}
