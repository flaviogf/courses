using System.Collections.Generic;

namespace CursoEntityFrameworkCore.ConsoleApp
{
    public interface IProdutoRepository
    {
        void Adiciona(Produto produto);
        IEnumerable<Produto> Lista();
        Produto Busca(int id);
        void Atualiza(Produto produto);
        void Deleta(Produto produto);
    }
}
