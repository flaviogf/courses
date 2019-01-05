using System.Collections.Generic;

namespace CursoAspNetMvc5Alura.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        void Insere(T obj);
        IEnumerable<T> Lista();
    }
}
