using Microsoft.EntityFrameworkCore;

namespace Section3.LinqToEntities
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Track> Tracks { get; set; }

        public DbSet<Genre> Genres { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=127.0.0.1;Port=5432;Database=linqtoentity_section3;User Id=postgres;Password = postgres;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().HasData
            (
                new Genre
                {
                    Id = 1,
                    Name = "Rock"
                }
            );

            modelBuilder.Entity<Genre>().HasData
            (
                new Genre
                {
                    Id = 2,
                    Name = "Reggae"
                }
            );

            modelBuilder.Entity<Genre>().HasData
            (
                new Genre
                {
                    Id = 3,
                    Name = "Classic"
                }
            );

            modelBuilder.Entity<Track>().HasData
            (
                new Track
                {
                    Id = 1,
                    Name = "Sweet Child O' Mine",
                    GenreId = 1
                }
            );

            modelBuilder.Entity<Track>().HasData
            (
                new Track
                {
                    Id = 2,
                    Name = "I Shot The Sheriff",
                    GenreId = 2
                }
            );

            modelBuilder.Entity<Track>().HasData
            (
                new Track
                {
                    Id = 3,
                    Name = "Danubio Azul",
                    GenreId = 3
                }
            );
        }
    }
}
