using ByteBank.Api.Models;
using ByteBank.Api.ViewModels.SignIn;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Api.Controllers
{
    [ApiController]
    [Route("/api/signin")]
    public class SignInController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public SignInController(IConfiguration configuration, SignInManager<ApplicationUser> signInManager)
        {
            _configuration = configuration;
            _signInManager = signInManager;
        }

        [HttpPost]
        [Route("")]
        [AllowAnonymous]
        public async Task<IActionResult> Store([FromBody]StoreSignViewModel viewModel)
        {
            var result = await _signInManager.PasswordSignInAsync(viewModel.Email, viewModel.Password, isPersistent: false, lockoutOnFailure: false);

            if (!result.Succeeded)
            {
                return Unauthorized();
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:JwtBearer:Secret"]));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, "")
            };

            var token = new JwtSecurityToken(_configuration["Authentication:JwtBearer:Issuer"], _configuration["Authentication:JwtBearer:Audience"], claims, expires: DateTime.Now.AddMinutes(5), signingCredentials: credentials);

            var handler = new JwtSecurityTokenHandler();

            return Ok(handler.WriteToken(token));
        }
    }
}
