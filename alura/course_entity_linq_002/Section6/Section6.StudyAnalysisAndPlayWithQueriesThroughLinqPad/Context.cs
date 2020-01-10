using Microsoft.EntityFrameworkCore;

namespace Section6.StudyAnalysisAndPlayWithQueriesThroughLinqPad
{
    public class Context : DbContext
    {
        public DbSet<Track> Tracks { get; set; }

        public DbSet<Genre> Genres { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\flavio\dev\courses\alura\course_entity_linq_002\Section6\Section6.StudyAnalysisAndPlayWithQueriesThroughLinqPad\database.mdf;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Genre

            modelBuilder.Entity<Genre>()
                .ToTable("Genero");

            modelBuilder.Entity<Genre>()
                .Property(it => it.Id).HasColumnName("GeneroId");

            modelBuilder.Entity<Genre>()
                .Property(it => it.Name).HasColumnName("Nome");

            #endregion

            #region Track

            modelBuilder.Entity<Track>()
                .ToTable("Faixa");

            modelBuilder.Entity<Track>()
                .Property(it => it.Id).HasColumnName("FaixaId");

            modelBuilder.Entity<Track>()
                .Property(it => it.Name).HasColumnName("Nome");

            modelBuilder.Entity<Track>()
                .Property(it => it.GenreId).HasColumnName("GeneroId");

            #endregion
        }
    }
}
