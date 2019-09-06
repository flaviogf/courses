using Microsoft.EntityFrameworkCore;
using Store.Cli.Models;

namespace Store.Cli
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=db.sqlite3");
        }

        public DbSet<Product> Products { get; set; }
    }
}
