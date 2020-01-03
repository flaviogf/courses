using ExternalProvider.Mvc.Data;
using ExternalProvider.Mvc.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ExternalProvider.Mvc
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = _configuration.GetConnectionString("Default");

            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connectionString));

            services
                .AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationContext>()
                .AddDefaultTokenProviders();

            services
                .AddAuthentication()
                .AddGoogle(options =>
                {
                    options.ClientId = _configuration.GetValue<string>("Providers:Google:ClientId");
                    options.ClientSecret = _configuration.GetValue<string>("Providers:Google:ClientSecret");
                    options.SaveTokens = true;
                });

            services.AddMvc(options => options.EnableEndpointRouting = false);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(options => options.MapRoute("default", "{controller=SignIn}/{action=Store}/{id?}"));
        }
    }
}
