using CursoAspNetMvc5Alura.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace CursoAspNetMvc5Alura.Data.EntityType
{
    public class ClienteEntityType : EntityTypeConfiguration<Cliente>
    {
        public ClienteEntityType()
        {
            Property(it => it.DataCadastro).HasColumnType("datetime2");
        }
    }
}
