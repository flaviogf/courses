using System;
using System.IO;
using System.Linq;
using System.Reflection;
using AutoMapper;
using Library.Api.OperationFilters;
using Library.Api.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc.Versioning;
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

            services.AddApiVersioning(it =>
            {
                it.AssumeDefaultVersionWhenUnspecified = true;
                it.DefaultApiVersion = new ApiVersion(1, 0);
                it.ReportApiVersions = true;
            });

            services.AddVersionedApiExplorer(it =>
            {
                it.GroupNameFormat = "'v'VV";
            });

            services.AddControllers(it =>
            {
                it.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status400BadRequest));
                it.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status406NotAcceptable));
                it.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status500InternalServerError));

                it.ReturnHttpNotAcceptable = true;

                it.OutputFormatters.Add(new XmlSerializerOutputFormatter());
            });

            var apiVersionDescriptionProvider = services.BuildServiceProvider().GetService<IApiVersionDescriptionProvider>();

            services.AddSwaggerGen(it =>
            {
                foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
                {
                    it.SwaggerDoc($"LibraryOpenApiSpecification{description.GroupName}", new OpenApiInfo
                    {
                        Title = "Library API",
                        Version = description.ApiVersion.ToString(),
                        Description = "Through this api you can access authors and bookx.",
                        Contact = new OpenApiContact
                        {
                            Email = "flavio@flaviogf.com.br",
                            Name = "Flavio",
                            Url = new Uri("https://flaviogf.com.br")
                        },
                        License = new OpenApiLicense
                        {
                            Name = "MIT",
                            Url = new Uri("https://opensource.org/licenses/MIT")
                        }
                    });
                }

                it.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));

                it.OperationFilter<GetBookOperationFilter>();

                it.DocInclusionPredicate((name, description) =>
                {
                    var model = description.ActionDescriptor.GetApiVersionModel(ApiVersionMapping.Explicit | ApiVersionMapping.Implicit);

                    if (model == null)
                    {
                        return true;
                    }

                    if (model.DeclaredApiVersions.Any())
                    {
                        return model.DeclaredApiVersions.Any(v => $"LibraryOpenApiSpecificationv{v.ToString()}" == name);
                    }

                    return model.ImplementedApiVersions.Any(v => $"LibraryOpenApiSpecificationv{v.ToString()}" == name);
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider apiVersionDescriptionProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseSwagger();

            app.UseSwaggerUI(it =>
            {
                foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
                {
                    it.SwaggerEndpoint($"/swagger/LibraryOpenApiSpecification{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                }

                it.RoutePrefix = string.Empty;
            });

            app.UseEndpoints(it => it.MapControllers());
        }
    }
}
