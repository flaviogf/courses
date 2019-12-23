using Bytebank.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Bytebank.Api
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>().OwnsOne(it => it.Contact);
        }
    }
}
