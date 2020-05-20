using System.Reflection;
using AluraMovies.App.Models;
using Microsoft.EntityFrameworkCore;

namespace AluraMovies.App.Data
{
    public class Context : DbContext
    {
        public DbSet<Actor> Actors { get; set; }

        public DbSet<Movie> Movies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=AluraMovies;User=sa;Password=Test123@;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
