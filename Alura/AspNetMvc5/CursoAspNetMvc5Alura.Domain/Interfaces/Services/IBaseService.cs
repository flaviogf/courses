using System.Collections.Generic;

namespace CursoAspNetMvc5Alura.Domain.Interfaces.Services
{
    public interface IBaseService<T> where T : class
    {
        void Insere(T obj);
        IEnumerable<T> Lista();
    }
}
