using System;
using System.IO;
using System.Reflection;
using AutoMapper;
using Library.Api.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Library.Api
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
            services.AddDbContext<ApplicationContext>(it => it.UseSqlite(_configuration.GetConnectionString("Default")));

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<IAuthorRepository, AuthorRepository>();

            services.AddControllers();

            services.AddSwaggerGen(it =>
            {
                it.SwaggerDoc("LibraryOpenApiSpecification", new OpenApiInfo
                {
                    Title = "Library API",
                    Version = "1"
                });

                it.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseSwagger();

            app.UseSwaggerUI(it =>
            {
                it.SwaggerEndpoint("/swagger/LibraryOpenApiSpecification/swagger.json", "Library API");
                it.RoutePrefix = string.Empty;
            });

            app.UseEndpoints(it => it.MapControllers());
        }
    }
}
