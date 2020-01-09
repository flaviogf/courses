using Microsoft.EntityFrameworkCore;

namespace Section4.EnjoyParallelProgrammingResourceWithParallelLinq
{
    public class Context : DbContext
    {
        public DbSet<Track> Tracks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            const string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\flavio\dev\courses\alura\course_entity_linq_002\Section4\Section4.EnjoyParallelProgrammingResourceWithParallelLinq\database.mdf;Integrated Security=True;Connect Timeout=30";

            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Track>()
                .ToTable("Faixa");

            modelBuilder.Entity<Track>()
                .Property(it => it.Id).HasColumnName("FaixaId");

            modelBuilder.Entity<Track>()
                .Property(it => it.Name).HasColumnName("Nome");
        }
    }
}
