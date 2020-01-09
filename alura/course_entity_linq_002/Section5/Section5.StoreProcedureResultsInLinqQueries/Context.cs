using Microsoft.EntityFrameworkCore;

namespace Section5.StoreProcedureResultsInLinqQueries
{
    public class Context : DbContext
    {
        public DbSet<InvoiceItem> InvoiceItem { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\flavio\dev\courses\alura\course_entity_linq_002\Section5\Section5.StoreProcedureResultsInLinqQueries\database.mdf;Integrated Security=True;Connect Timeout=30";

            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Track

            modelBuilder.Entity<Track>()
                .ToTable("Faixa");

            modelBuilder.Entity<Track>()
                .Property(it => it.Id).HasColumnName("FaixaId");

            modelBuilder.Entity<Track>()
                .Property(it => it.Name).HasColumnName("Nome");

            #endregion

            #region Invoice

            modelBuilder.Entity<Invoice>()
                .ToTable("NotaFiscal");

            modelBuilder.Entity<Invoice>()
                .Property(it => it.Id).HasColumnName("NotaFiscalId");

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

            modelBuilder.Entity<InvoiceItem>()
                .Property(it => it.Price).HasColumnName("PrecoUnitario");

            modelBuilder.Entity<InvoiceItem>()
                .Property(it => it.Quantity).HasColumnName("Quantidade");

            #endregion
        }
    }
}
