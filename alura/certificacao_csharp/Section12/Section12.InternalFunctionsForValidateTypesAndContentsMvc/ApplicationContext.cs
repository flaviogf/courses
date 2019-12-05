using Microsoft.EntityFrameworkCore;
using Section12.InternalFunctionsForValidateTypesAndContentsMvc.Models;

namespace Section12.InternalFunctionsForValidateTypesAndContentsMvc
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
    }
}
