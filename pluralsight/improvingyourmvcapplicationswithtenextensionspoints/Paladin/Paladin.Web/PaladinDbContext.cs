using Paladin.Web.Models;
using System.Data.Entity;

namespace Paladin.Web
{
    public class PaladinDbContext : DbContext
    {
        public DbSet<Applicant> Applicant { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Employement> Employements { get; set; }

        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<Product> Products { get; set; }
    }
}