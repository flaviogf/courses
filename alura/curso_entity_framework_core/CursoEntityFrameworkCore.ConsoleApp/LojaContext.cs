using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace CursoEntityFrameworkCore.ConsoleApp
{
    public class LojaContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<Promocao> Promocoes { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var console = new ConsoleLoggerProvider(
                (category, level) => category == DbLoggerCategory.Database.Command.Name && level == LogLevel.Information, true
            );

            var logger = new LoggerFactory(new[] { console });

            optionsBuilder
                .UseLoggerFactory(logger)
                .UseSqlite("Data Source=loja.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<PromocaoProduto>()
                .HasKey(it => new { it.ProdutoId, it.PromocaoId });

            modelBuilder
                .Entity<Endereco>()
                .Property<int>("ClienteId");

            modelBuilder
                .Entity<Endereco>()
                .HasKey("ClienteId");
        }
    }
}
