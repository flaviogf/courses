using Microsoft.EntityFrameworkCore;
using Section6.CoutingAndTotaling.Models;

namespace Section6.CoutingAndTotaling
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> option) : base(option)
        {

        }

        public DbSet<Artist> Artists { get; set; }

        public DbSet<Album> Albums { get; set; }

        public DbSet<Track> Tracks { get; set; }

        public DbSet<Item> Items { get; set; }
    }
}