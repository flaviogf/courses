using CarvedRock.Api.GraphQL;
using CarvedRock.Api.GraphQL.Types;
using CarvedRock.Api.Repositories;
using GraphQL.Server;
using GraphQL.Types;
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
            services.AddDbContext<CarvedRockDbContext>(it => it.UseSqlite(_configuration.GetConnectionString("Default")), ServiceLifetime.Singleton);

            services.AddSingleton<IProductRepository, ProductRepository>();

            services.AddSingleton<IProductReviewRepository, ProductReviewRepository>();

            services.AddSingleton<ProductType>();

            services.AddSingleton<ProductTypeEnumType>();

            services.AddSingleton<ProductReviewType>();

            services.AddSingleton<CarvedRockQuery>();

            services.AddSingleton<CarvedRockMutation>();

            services.AddSingleton<ISchema, CarvedRockSchema>();

            services.AddHttpContextAccessor();

            services
                .AddGraphQL(it =>
                {
                    it.EnableMetrics = true;
                })
                .AddErrorInfoProvider(it => it.ExposeExceptionStackTrace = true)
                .AddSystemTextJson()
                .AddGraphTypes(ServiceLifetime.Singleton);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseGraphQL<ISchema>();

            app.UseGraphQLPlayground();
        }
    }
}
