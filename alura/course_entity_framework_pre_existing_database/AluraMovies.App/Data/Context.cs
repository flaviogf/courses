using AluraMovies.App.Models;
using Microsoft.EntityFrameworkCore;

namespace AluraMovies.App.Data
{
    public class Context : DbContext
    {
        public DbSet<Actor> Actors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=AluraMovies;User=sa;Password=Test123@;");
        }
    }
}
