using CursoAspNetMvc5Alura.Domain.Interfaces.Repositories;
using CursoAspNetMvc5Alura.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace CursoAspNetMvc5Alura.Domain.Services
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        private readonly IBaseRepository<T> _repository;

        public BaseService(IBaseRepository<T> repository)
        {
            _repository = repository;
        }

        public void Insere(T obj)
        {
            _repository.Insere(obj);
        }

        public IEnumerable<T> Lista()
        {
            return _repository.Lista();            
        }
    }
}
