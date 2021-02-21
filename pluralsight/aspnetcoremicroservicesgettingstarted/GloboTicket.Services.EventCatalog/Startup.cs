using System.Reflection;
using GloboTicket.Services.EventCatalog.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GloboTicket.Services.EventCatalog
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
            services.AddDbContext<EventCatalogDbContext>(it => it.UseSqlite(_configuration.GetConnectionString("EventCatalogDbContext")));

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<ICategoryRepository, EFCategoryRepository>();

            services.AddSwaggerGen();

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(it =>
            {
                it.SwaggerEndpoint("swagger/v1/swagger.json", "Globo Ticket Event Catalog");

                it.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseEndpoints(it => it.MapControllers());
        }
    }
}
