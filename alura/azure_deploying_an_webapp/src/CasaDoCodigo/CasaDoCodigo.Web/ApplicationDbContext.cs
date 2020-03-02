using CasaDoCodigo.Web.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace CasaDoCodigo.Web
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuthorBooks>().HasKey(it => new { it.AuthorId, it.BookId });
            modelBuilder.Entity<AuthorBooks>().HasOne(it => it.Author).WithMany(it => it.Books).HasForeignKey(it => it.AuthorId);
            modelBuilder.Entity<AuthorBooks>().HasOne(it => it.Book).WithMany(it => it.Authors).HasForeignKey(it => it.BookId);

            var paulo = new Author
            {
                Id = Guid.NewGuid(),
                Name = "Paulo Silveira"
            };

            var rodrigo = new Author
            {
                Id = Guid.NewGuid(),
                Name = "Rodrigo Turini"
            };

            var java8 = new Book
            {
                Id = Guid.NewGuid(),
                Name = "Java 8 Prático"
            };

            var pauloBooks = new AuthorBooks
            {
                AuthorId = paulo.Id,
                BookId = java8.Id
            };

            var rodrigoBooks = new AuthorBooks
            {
                AuthorId = rodrigo.Id,
                BookId = java8.Id
            };

            modelBuilder.Entity<Author>().HasData(paulo, rodrigo);

            modelBuilder.Entity<Book>().HasData(java8);

            modelBuilder.Entity<AuthorBooks>().HasData(pauloBooks, rodrigoBooks);
        }
    }
}
