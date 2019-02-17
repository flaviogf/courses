using CursoAspNetMvc5Alura.Domain.Interfaces.Repositories;
using CursoAspNetMvc5Alura.Domain.Interfaces.Services;
using CursoAspNetMvc5Alura.Domain.Models;

namespace CursoAspNetMvc5Alura.Domain.Services
{
    public class ClienteService : BaseService<Cliente>, IClienteService
    {
        public ClienteService(IClienteRepository repository) : base(repository)
        {
        }
    }
}
