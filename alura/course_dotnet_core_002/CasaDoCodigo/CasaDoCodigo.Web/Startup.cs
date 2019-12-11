using CasaDoCodigo.Web.Database;
using CasaDoCodigo.Web.Lib;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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

            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connectionString));

            services.AddHttpContextAccessor();

            services.AddDistributedMemoryCache();

            services.AddSession();

            services.AddScoped<IShoppingCart, ShoppingCartSession>();

            services.AddMvc(setup => setup.EnableEndpointRouting = false);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseSession();

            app.UseMvc(routes => routes.MapRoute("default", "{controller=Catalog}/{action=Index}/{id?}"));
        }
    }
}
