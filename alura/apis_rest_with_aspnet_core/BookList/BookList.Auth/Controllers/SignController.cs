using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BookList.Auth.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace BookList.Auth.Controllers
{
    [ApiController]
    [Route("api/auth/[controller]")]
    public class SignInController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInManager;

        private readonly ILogger<SignInController> _logger;

        private readonly IConfiguration _configuration;

        public SignInController
        (
            SignInManager<ApplicationUser> signInManager,
            ILogger<SignInController> logger,
            IConfiguration configuration
        )
        {
            _signInManager = signInManager;
            _logger = logger;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> Store([FromBody] SignInViewModel viewModel)
        {
            var result = await _signInManager.PasswordSignInAsync(viewModel.Email, viewModel.Password, true, false);

            if (!result.Succeeded)
            {
                return Unauthorized();
            }

            var key = Encoding.UTF8.GetBytes(_configuration.GetValue<string>("SecretKey"));

            var signInCredentials = new SigningCredentials(new SymmetricSecurityKey(key), "HS256");

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, viewModel.Email)
            };

            var subject = new ClaimsIdentity(claims);

            var descriptor = new SecurityTokenDescriptor
            {
                Subject = subject,
                SigningCredentials = signInCredentials
            };

            var handler = new JwtSecurityTokenHandler();

            var securityToken = handler.CreateToken(descriptor);

            var token = handler.WriteToken(securityToken);

            _logger.LogInformation($"|> User logged in  -> {viewModel.Email}");

            return Ok(token);
        }
    }
}
