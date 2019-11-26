using Microsoft.EntityFrameworkCore;
using System;

namespace Section10.CreateAndApplyAttributes
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=database.sqlite");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sale>().HasData(
                new Sale
                {
                    Id = 1,
                    Amount = 1000,
                    Date = DateTime.Now.AddDays(-5)
                },
                new Sale
                {
                    Id = 2,
                    Amount = 10000,
                    Date = DateTime.Now
                },
                new Sale
                {
                    Id = 3,
                    Amount = 100000,
                    Date = DateTime.Now.AddDays(5)
                }
            );
        }

        public DbSet<Sale> Sales { get; set; }
    }
}
