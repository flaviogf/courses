using CursoAspNetMvc5Alura.Application.Intefaces;
using CursoAspNetMvc5Alura.Domain.Interfaces.Services;
using CursoAspNetMvc5Alura.Domain.Models;

namespace CursoAspNetMvc5Alura.Application
{
    public class ClienteApplication : BaseApplication<Cliente>, IClienteApplication
    {
        public ClienteApplication(IClienteService service) : base(service)
        {
        }
    }
}
