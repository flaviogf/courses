using CasaDoCodigo.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace CasaDoCodigo.Web.Infrastrucutre
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
    }
}
