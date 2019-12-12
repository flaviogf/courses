using CasaDoCodigo.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace CasaDoCodigo.Web.Database
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new Product[]
            {
                new Product
                {
                    Id = 1,
                    Name = "ASP.NET Core MVC",
                    Price = 3900
                },
                new Product
                {
                    Id = 2,
                    Name = "Orientação a Objetos em C#",
                    Price = 3900
                },
                new Product
                {
                    Id = 3,
                    Name = "Programação funcional em .NET",
                    Price = 3900
                },
            });
        }
    }
}
