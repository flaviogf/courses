using System;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Library.Api.Authentication
{
    public class BaseAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public BaseAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
        {
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return Task.FromResult(AuthenticateResult.Fail("Missing Authorization header"));
            }

            try
            {
                var authenticationHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);

                var credentialBytes = Convert.FromBase64String(authenticationHeader.Parameter);

                var credentials = Encoding.UTF8.GetString(credentialBytes).Split(":");

                var username = credentials[0];

                var password = credentials[1];

                if (username != "Pluralsight" || password != "Pluralsight")
                {
                    return Task.FromResult(AuthenticateResult.Fail("Invalid username or password"));
                }

                var claims = new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, username)
                };

                var identity = new ClaimsIdentity(claims, Scheme.Name);

                var principal = new ClaimsPrincipal(identity);

                var ticket = new AuthenticationTicket(principal, Scheme.Name);

                return Task.FromResult(AuthenticateResult.Success(ticket));
            }
            catch
            {
                return Task.FromResult(AuthenticateResult.Fail("Invalida Authorization header"));
            }
        }
    }
}
