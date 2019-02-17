using System.Collections.Generic;
using System.Linq;
using CursoAspNetMvc5Alura.Domain.Interfaces.Repositories;

namespace CursoAspNetMvc5Alura.Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly CursoAspNetMvc5AluraContext _context;

        public BaseRepository(CursoAspNetMvc5AluraContext context)
        {
            _context = context;
        }

        public void Insere(T obj)
        {
            _context.Set<T>().Add(obj);
            _context.SaveChanges();
        }

        public IEnumerable<T> Lista()
        {
            return _context.Set<T>().ToList();
        }
    }
}
