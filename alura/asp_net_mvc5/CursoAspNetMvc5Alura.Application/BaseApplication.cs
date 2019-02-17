using System.Collections.Generic;
using CursoAspNetMvc5Alura.Application.Intefaces;
using CursoAspNetMvc5Alura.Domain.Interfaces.Services;

namespace CursoAspNetMvc5Alura.Application
{
    public class BaseApplication<T> : IBaseApplication<T> where T : class
    {
        private readonly IBaseService<T> _service;

        public BaseApplication(IBaseService<T> service)
        {
            _service = service;
        }

        public void Insere(T obj)
        {
            _service.Insere(obj);            
        }

        public IEnumerable<T> Lista()
        {
            return _service.Lista();
        }
    }
}
