using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PSStore.Application;
using PSStore.Application.Customers.Queries.GetCustomerList;
using PSStore.Application.Employees.Queries.GetEmployeeList;
using PSStore.Application.Products.Queries.GetProductList;
using PSStore.Persistence;
using PSStore.Persistence.Customers;
using PSStore.Persistence.Employees;
using PSStore.Persistence.Products;
using PSStore.Persistence.Sales;

namespace PSStore.Presentation
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
            services.AddDbContext<PSStoreDbContext>(it => it.UseSqlServer(_configuration.GetConnectionString("Default")));

            services.AddScoped<ICustomerRepository, EFCustomerRepository>();

            services.AddScoped<IEmployeeRepository, EFEmployeeRepository>();

            services.AddScoped<IProductRepository, EFProductRepository>();

            services.AddScoped<ISaleRepository, EFSaleRepository>();

            services.AddScoped<IGetCustomerListQuery, GetCustomerListQuery>();

            services.AddScoped<IGetEmployeeListQuery, GetEmployeeListQuery>();

            services.AddScoped<IGetProductListQuery, GetProductListQuery>();

            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(it => it.MapControllers());
        }
    }
}
