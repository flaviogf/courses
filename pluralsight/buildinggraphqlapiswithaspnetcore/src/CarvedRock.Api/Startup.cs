using CarvedRock.Api.GraphQL;
using CarvedRock.Api.Repositories;
using GraphQL.Server;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CarvedRock.Api
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
            services.AddDbContext<CarvedRockDbContext>(it => it.UseSqlite(_configuration.GetConnectionString("Default")));

            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<CarvedRockQuery>();

            services.AddScoped<CarvedRockSchema>();

            services.AddHttpContextAccessor();

            services
                .AddGraphQL(it =>
                {
                    it.EnableMetrics = true;
                })
                .AddSystemTextJson()
                .AddGraphTypes(ServiceLifetime.Scoped);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseGraphQL<CarvedRockSchema>();

            app.UseGraphQLPlayground();
        }
    }
}
