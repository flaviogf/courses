using CasaDoCodigo.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace CasaDoCodigo.Web.Infrastrucutre
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Cart> Carts { get; set; }

        public DbSet<CartItem> CartItems { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
    }
}
