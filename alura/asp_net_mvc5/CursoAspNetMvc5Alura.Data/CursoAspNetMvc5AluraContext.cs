using CursoAspNetMvc5Alura.Data.EntityType;
using CursoAspNetMvc5Alura.Domain.Models;
using System.Data.Entity;

namespace CursoAspNetMvc5Alura.Data
{
    public class CursoAspNetMvc5AluraContext: DbContext
    {
        public CursoAspNetMvc5AluraContext() : base("db")
        {
            CorrigeErroCarregamentoDll();
        }

        private static void CorrigeErroCarregamentoDll()
        {
            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new ClienteEntityType());
        }

        public DbSet<Cliente> Clientes { get; set; }
    }
}
