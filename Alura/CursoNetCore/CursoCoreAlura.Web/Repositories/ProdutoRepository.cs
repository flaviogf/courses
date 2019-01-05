using System.Collections.Generic;
using System.Linq;
using CursoCoreAlura.Web.Infra;
using CursoCoreAlura.Web.Models;

namespace CursoCoreAlura.Web.Repositories
{
    public interface IProdutoRepository
    {
        void Insere(Produto produto);

        void Insere(IEnumerable<Produto> produtos);

        IEnumerable<Produto> Lista();
    }

    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ApplicationContext _applicationContext;

        public ProdutoRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public void Insere(Produto produto)
        {
            _applicationContext.Produto.Add(produto);
            _applicationContext.SaveChanges();
        }

        public void Insere(IEnumerable<Produto> produtos)
        {
            _applicationContext.Produto.AddRange(produtos);
            _applicationContext.SaveChanges();
        }

        public IEnumerable<Produto> Lista()
        {
            return _applicationContext.Produto.OrderBy(p => p.Id);
        }
    }
}
