using System.Collections.Generic;

namespace CursoAspNetMvc5Alura.Application.Intefaces
{
    public interface IBaseApplication<T> where T : class
    {
        void Insere(T obj);
        IEnumerable<T> Lista();
    }
}
