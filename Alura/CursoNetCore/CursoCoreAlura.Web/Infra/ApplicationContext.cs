using CursoCoreAlura.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace CursoCoreAlura.Web.Infra
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Produto> Produto { get; set; }

        public DbSet<Pedido> Pedido { get; set; }

        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cadastro>().HasKey(it => it.Id);
            modelBuilder.Entity<Cadastro>().HasOne(it => it.Pedido).WithOne(it => it.Cadastro);


            modelBuilder.Entity<ItemPedido>().HasKey(it => it.Id);
            modelBuilder.Entity<ItemPedido>().HasOne(it => it.Pedido);
            modelBuilder.Entity<ItemPedido>().HasOne(it => it.Produto);

            modelBuilder.Entity<Pedido>().HasKey(it => it.Id);
            modelBuilder.Entity<Pedido>().HasMany(it => it.ItensPedido).WithOne(it => it.Pedido);
            modelBuilder.Entity<Pedido>().HasOne(it => it.Cadastro).WithOne(it => it.Pedido).IsRequired();

            modelBuilder.Entity<Produto>().HasKey(it => it.Id);
        }
    }
}
