using System;
using CursoCoreAlura.Web.Infra;
using CursoCoreAlura.Web.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace CursoCoreAlura.Web
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
//            services.AddEntityFrameworkNpgsql().AddDbContext<ApplicationContext>(options =>
//            {
//                var connectionString = _configuration.GetConnectionString("PostgreSQL");
//                options.UseNpgsql(connectionString);
//            });

            services.AddDbContext<ApplicationContext>(it => it.UseInMemoryDatabase("CursoCoreAlura"));

            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

            services.AddTransient<IProdutoRepository, ProdutoRepository>();
            services.AddTransient<IPedidoRepository, PedidoRepository>();
            services.AddTransient<ISeedService, SeedService>();

            services.AddSession();
            services.AddDistributedMemoryCache();

            services
                .AddMvc()
                .AddJsonOptions(it=> it.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            serviceProvider.GetService<ISeedService>().Inicializa();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseSession();

            app.UseMvc(routes => routes.MapRoute("default", "{controller=Home}/{action=Index}/{codigo?}"));
        }
    }
}
