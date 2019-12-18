using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace Section4.AssociatingAndFilteringTheModelEntities
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Artist> Artists { get; set; }

        public DbSet<Album> Albums { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var logger = LoggerFactory.Create((loggingBuilder) =>
            {
                loggingBuilder.AddConsole();
            });

            optionsBuilder.UseLoggerFactory(logger).UseNpgsql("Server=127.0.0.1; Port=5432; Database=linqtoentity_section4; User Id=postgres; Password=postgres;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var artists = from id in Enumerable.Range(1, 10)
                          select new Faker<Artist>()
                          .RuleFor(it => it.Id, () => id)
                          .RuleFor(it => it.Name, (faker) => faker.Person.FullName)
                          .Generate();

            modelBuilder.Entity<Artist>().HasData(artists);


            var albums = from id in Enumerable.Range(1, 10)
                         select new Faker<Album>()
                         .RuleFor(it => it.Id, () => id)
                         .RuleFor(it => it.Name, (faker) => faker.Person.FullName)
                         .RuleFor(it => it.ArtistId, (faker) => faker.Random.Int(1, 10))
                         .Generate();

            modelBuilder.Entity<Album>().HasData(albums);
        }
    }
}
