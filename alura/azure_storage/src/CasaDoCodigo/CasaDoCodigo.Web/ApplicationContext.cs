using CasaDoCodigo.Web.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace CasaDoCodigo.Web
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<File> Files { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookAuthor>().HasKey(it => new { it.BookId, it.AuthorId });

            modelBuilder.Entity<Author>().HasData(
                new Author
                {
                    Id = Guid.NewGuid(),
                    Name = "Paulo Silveira"
                },
                new Author
                {
                    Id = Guid.NewGuid(),
                    Name = "Guilherme Silveira"
                }
            );
        }
    }
}
