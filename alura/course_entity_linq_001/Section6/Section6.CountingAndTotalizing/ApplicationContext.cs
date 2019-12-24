using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace Section6.CountingAndTotalizing
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Artist> Artists { get; set; }

        public DbSet<Album> Albums { get; set; }

        public DbSet<Track> Tracks { get; set; }

        public DbSet<Item> Items { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var loggerFactory = LoggerFactory.Create(configure => configure.AddConsole());

            var connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\flavi\dev\courses\alura\course_entity_linq_001\Section6\Section6.CountingAndTotalizing\database.mdf;Integrated Security=True;Connect Timeout=30";

            optionsBuilder.UseSqlServer(connectionString).UseLoggerFactory(loggerFactory);
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
                         .RuleFor(it => it.Title, (faker) => faker.Lorem.Sentence())
                         .RuleFor(it => it.ArtistId, (faker) => faker.Random.Int(1, 10))
                         .Generate();

            modelBuilder.Entity<Album>().HasData(albums);

            var tracks = from id in Enumerable.Range(1, 10)
                         select new Faker<Track>()
                         .RuleFor(it => it.Id, () => id)
                         .RuleFor(it => it.Name, (faker) => faker.Lorem.Sentence())
                         .RuleFor(it => it.AlbumId, (faker) => faker.Random.Int(1, 10))
                         .RuleFor(it => it.Price, (faker) => faker.Random.Int(10000, 20000))
                         .Generate();

            modelBuilder.Entity<Track>().HasData(tracks);

            var items = from id in Enumerable.Range(1, 10)
                        select new Faker<Item>()
                        .RuleFor(it => it.Id, () => id)
                        .RuleFor(it => it.TrackId, (faker) => faker.Random.Int(1, 10))
                        .RuleFor(it => it.Quantity, (faker) => faker.Random.Int(100, 200))
                        .RuleFor(it => it.Price, (faker) => faker.Random.Int(10000, 20000))
                        .Generate();

            modelBuilder.Entity<Item>().HasData(items);
        }
    }
}
