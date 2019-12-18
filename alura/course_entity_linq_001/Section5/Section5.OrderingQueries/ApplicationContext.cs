using Bogus;
using Microsoft.EntityFrameworkCore;
using Section5.OrderingQueries.Models;
using System.Linq;

namespace Section5.OrderingQueries
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<Artist> Artists { get; set; }

        public DbSet<Album> Albums { get; set; }

        public DbSet<Track> Tracks { get; set; }

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
                         .RuleFor(it => it.Name, (faker) => faker.Company.CompanyName())
                         .RuleFor(it => it.ArtistId, (faker) => faker.Random.Int(1, 10))
                         .Generate();

            modelBuilder.Entity<Album>().HasData(albums);

            var tracks = from id in Enumerable.Range(1, 10)
                         select new Faker<Track>()
                         .RuleFor(it => it.Id, () => id)
                         .RuleFor(it => it.Name, (faker) => faker.Company.CompanyName())
                         .RuleFor(it => it.AlbumId, (faker) => faker.Random.Int(1, 10))
                         .Generate();

            modelBuilder.Entity<Track>().HasData(tracks);
        }
    }
}
