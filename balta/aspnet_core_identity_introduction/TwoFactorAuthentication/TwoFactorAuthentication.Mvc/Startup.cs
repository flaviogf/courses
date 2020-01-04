using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using TwoFactorAuthentication.Mvc.Data;
using TwoFactorAuthentication.Mvc.Models;

namespace TwoFactorAuthentication.Mvc
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
            services.AddDbContext<ApplicationContext>(options => options.UseSqlite("Data Source=database.db"));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                    .AddEntityFrameworkStores<ApplicationContext>()
                    .AddDefaultTokenProviders();

            services.AddAuthentication()
                    .AddGitHub(options =>
                    {
                        options.ClientId = _configuration["GitHub:ClientId"];
                        options.ClientSecret = _configuration["GitHub:ClientSecret"];
                        options.SaveTokens = true;
                        options.Scope.Add("user:email");
                    });

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/SignIn/Store";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
                options.SlidingExpiration = true;
            });

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(options => options.MapControllerRoute("default", "{controller=SignIn}/{action=Store}/{id?}"));
        }
    }
}

