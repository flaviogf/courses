using System.Collections.Generic;
using casa_do_codigo_core.Models;

namespace casa_do_codigo_core
{

    public interface IDataService
    {
        void InicializaDb();
        List<Produto> GetProdutos();
        List<ItemCarrinho> GetItensCarrinho();
        UpdateItemCarrinhoResponse UpdateItemCarrinho(ItemCarrinho itemCarrinho);
        void AddItemCarrinho(int produtoId);
    }
}