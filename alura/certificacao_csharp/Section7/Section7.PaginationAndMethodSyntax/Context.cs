using Microsoft.EntityFrameworkCore;
using Section7.PaginationAndMethodSyntax.Models;

namespace Section7.PaginationAndMethodSyntax
{
    public class Context : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<File> Files { get; set; }

        public Context()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlite("Data Source=database.sqlite");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<File>().HasData(
                new File
                {
                    Id = 1,
                    Name = "default",
                    Path = "default.jpg"
                }
            );

            builder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Name = "Flavio",
                    Email = "flavio@email.com",
                    FileId = 1
                },
                new User
                {
                    Id = 2,
                    Name = "Fernando",
                    Email = "fernando@email.com",
                    FileId = 1
                },
                new User
                {
                    Id = 3,
                    Name = "Luis",
                    Email = "luis@email.com",
                    FileId = 1
                },
                new User
                {
                    Id = 4,
                    Name = "Fatima",
                    Email = "fatima@email.com",
                    FileId = 1
                }
            );
        }
    }
}