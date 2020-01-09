using Microsoft.EntityFrameworkCore;

namespace Section1.CustomersThatHaveBoughtTheMostExpensiveProduct
{
    public class Context : DbContext
    {
        public DbSet<Track> Tracks { get; set; }

        public DbSet<InvoiceItem> InvoiceItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            const string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\flavio\dev\courses\alura\course_entity_linq_002\Section1\Section1.CustomersThatHaveBoughtTheMostExpensiveProduct\database.mdf;Integrated Security=True;Connect Timeout=30";

            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Invoice

            modelBuilder.Entity<Invoice>()
                   .ToTable("NotaFiscal");

            modelBuilder.Entity<Invoice>()
                .Property(it => it.Id).HasColumnName("NotaFiscalId");

            modelBuilder.Entity<Invoice>()
                .Property(it => it.CustomerId).HasColumnName("ClienteId");

            #endregion

            #region Customer

            modelBuilder.Entity<Customer>()
                .ToTable("Cliente");

            modelBuilder.Entity<Customer>()
                .Property(it => it.Id).HasColumnName("ClienteId");

            modelBuilder.Entity<Customer>()
                .Property(it => it.FirstName).HasColumnName("PrimeiroNome");

            modelBuilder.Entity<Customer>()
                .Property(it => it.LastName).HasColumnName("Sobrenome");

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

            modelBuilder.Entity<InvoiceItem>()
                .Property(it => it.Price).HasColumnName("PrecoUnitario");

            modelBuilder.Entity<InvoiceItem>()
                .Property(it => it.Quantity).HasColumnName("Quantidade");

            #endregion
        }
    }
}
