using CursoAspNetMvc5Alura.Domain.Interfaces.Repositories;
using CursoAspNetMvc5Alura.Domain.Models;

namespace CursoAspNetMvc5Alura.Data.Repositories
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(CursoAspNetMvc5AluraContext context) : base(context)
        {
        }
    }
}
