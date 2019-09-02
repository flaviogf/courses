using BookList.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace BookList.Api
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
    }
}
