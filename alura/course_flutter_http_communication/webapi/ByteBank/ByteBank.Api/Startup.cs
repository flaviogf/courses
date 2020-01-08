using ByteBank.Api.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ByteBank.Api
{
    public class Startup
    {
        private IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));

            services
                .AddIdentity<ApplicationUser, IdentityRole>(options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequiredLength = 8;
                    options.Password.RequiredUniqueChars = 1;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                })
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<ApplicationContext>();

            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters.ValidateIssuer = true;
                    options.TokenValidationParameters.ValidateAudience = true;
                    options.TokenValidationParameters.ValidateIssuerSigningKey = true;
                    options.TokenValidationParameters.ValidIssuer = _configuration["Authentication:JwtBearer:Issuer"];
                    options.TokenValidationParameters.ValidAudience = _configuration["Authentication:JwtBearer:Audience"];
                    options.TokenValidationParameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:JwtBearer:Secret"]));
                });

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(options => options.MapControllers());
        }
    }
}
