using System.Collections.Generic;
using System.Linq;

namespace CursoEntityFrameworkCore.ConsoleApp
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly LojaContext _context;

        public ProdutoRepository(LojaContext context)
        {
            _context = context;
        }

        public void Adiciona(Produto produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();
        }

        public void Atualiza(Produto produto)
        {
            _context.Entry(produto);
            _context.SaveChanges();
        }

        public Produto Busca(int id)
        {
            return _context.Produtos.FirstOrDefault(it => it.Id == id);
        }

        public void Deleta(Produto produto)
        {
            _context.Remove(produto);
            _context.SaveChanges();
        }

        public IEnumerable<Produto> Lista()
        {
            return _context.Produtos;
        }
    }
}
