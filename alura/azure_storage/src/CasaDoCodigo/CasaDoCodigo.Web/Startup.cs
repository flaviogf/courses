using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoMapper;
using System.Reflection;
using CasaDoCodigo.Web.ViewModels;
using CasaDoCodigo.Web.Models;
using CasaDoCodigo.Web.Infrastructure;

namespace CasaDoCodigo.Web
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

            services.AddDbContext<ApplicationContext>(it => it.UseSqlServer(connectionString));

            services.AddScoped<IFileUpload, AzureFileUpload>();

            services.AddAutoMapper(it =>
            {
                it.CreateMap<Book, BookViewModel>();
            }, Assembly.GetExecutingAssembly());

            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(it => it.MapDefaultControllerRoute());
        }
    }
}
