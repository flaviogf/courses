using Microsoft.EntityFrameworkCore;
using TodoList.Core;

namespace TodoList.CommandLine
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Todo> Todos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlite("Data Source=db.sqlite3");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<Todo>()
                .HasKey(it => it.Id);

            modelBuilder
                .Entity<Todo>()
                .Property(it => it.Title);

            modelBuilder
                .Entity<Todo>()
                .Property(it => it.Deadline);
        }
    }
}
