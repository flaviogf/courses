using casa_do_codigo_core.Models;
using Microsoft.EntityFrameworkCore;

namespace casa_do_codigo_core
{

    public class Contexto : DbContext
    {

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<ItemCarrinho> ItensCarrinho { get; set; }

        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }
    }
}