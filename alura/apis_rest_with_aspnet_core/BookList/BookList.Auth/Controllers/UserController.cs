using System.Threading.Tasks;
using BookList.Auth.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BookList.Auth.Controllers
{
    [ApiController]
    [Route("api/auth/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly ILogger<UserController> _logger;

        public UserController
        (
            UserManager<ApplicationUser> userManager,
            ILogger<UserController> logger
        )
        {
            _userManager = userManager;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Store([FromBody] UserViewModel viewModel)
        {
            var user = new ApplicationUser { UserName = viewModel.Email, Email = viewModel.Email };

            var result = await _userManager.CreateAsync(user, viewModel.Password);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            _logger.LogInformation($"|> User created -> {user.Email}");

            return Created($"api/auth/user/{user.Id}", viewModel);
        }
    }
}
