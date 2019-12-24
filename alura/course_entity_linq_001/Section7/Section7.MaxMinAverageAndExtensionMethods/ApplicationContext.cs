using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Section7.MaxMinAverageAndExtensionMethods
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Employe> Employes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var loggerFactory = LoggerFactory.Create(configure => configure.AddConsole());

            var connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\flavi\dev\courses\alura\course_entity_linq_001\Section7\Section7.MaxMinAverageAndExtensionMethods\database.mdf;Integrated Security=True;Connect Timeout=30";

            optionsBuilder.UseSqlServer(connectionString).UseLoggerFactory(loggerFactory);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employe>().HasData
            (
                new Employe
                {
                    Id = 1,
                    Name = "Flavio",
                    Salary = 500M
                },
                new Employe
                {
                    Id = 2,
                    Name = "Fernando",
                    Salary = 5000M
                },
                new Employe
                {
                    Id = 3,
                    Name = "Fatima",
                    Salary = 5000M
                },
                new Employe
                {
                    Id = 4,
                    Name = "Luis Fernando",
                    Salary = 15000M
                }
            );
        }
    }
}
