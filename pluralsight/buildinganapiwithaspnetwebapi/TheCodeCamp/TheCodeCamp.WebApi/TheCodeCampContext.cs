using System.Data.Entity;
using TheCodeCamp.WebApi.Models;

namespace TheCodeCamp.WebApi
{
    public class TheCodeCampContext : DbContext
    {
        public DbSet<Speaker> Speakers { get; set; }

        public DbSet<Camp> Camps { get; set; }

        public DbSet<Talk> Talks { get; set; }
    }
}