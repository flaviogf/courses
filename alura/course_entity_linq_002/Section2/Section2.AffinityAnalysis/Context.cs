using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Section2.AffinityAnalysis
{
    public class Context : DbContext
    {
        public DbSet<Track> Tracks { get; set; }

        public DbSet<InvoiceItem> InvoiceItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            const string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\flavio\dev\courses\alura\course_entity_linq_002\Section2\Section2.AffinityAnalysis\database.mdf;Integrated Security=True;Connect Timeout=30";

            optionsBuilder.UseSqlServer(connectionString);

            var loggerFactory = LoggerFactory.Create(options => options.AddConsole());

            optionsBuilder.UseLoggerFactory(loggerFactory);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Invoice

            modelBuilder.Entity<Invoice>()
                .ToTable("NotaFiscal");

            modelBuilder.Entity<Invoice>()
                .Property(it => it.Id).HasColumnName("NotaFiscalId");

            #endregion

            #region Track

            modelBuilder.Entity<Track>()
                .ToTable("Faixa");

            modelBuilder.Entity<Track>()
                .Property(it => it.Id).HasColumnName("FaixaId");

            modelBuilder.Entity<Track>()
                .Property(it => it.Name).HasColumnName("Nome");

            #endregion

            #region InvoiceItem

            modelBuilder.Entity<InvoiceItem>()
                .ToTable("ItemNotaFiscal");

            modelBuilder.Entity<InvoiceItem>()
                .HasKey(it => new { it.InvoiceId, it.TrackId });

            modelBuilder.Entity<InvoiceItem>()
               .Property(it => it.InvoiceId).HasColumnName("NotaFiscalId");

            modelBuilder.Entity<InvoiceItem>()
                .Property(it => it.TrackId).HasColumnName("FaixaId");

            #endregion
        }
    }
}
