using System.Collections.Generic;
using System.Linq;
using casa_do_codigo_core.Models;
using casa_do_codigo_core.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace casa_do_codigo_core
{

    public class DataService : IDataService
    {

        private readonly Contexto contexto;

        public DataService(Contexto contexto)
        {
            this.contexto = contexto;
        }

        public void InicializaDb()
        {
            this.contexto.Database.EnsureCreated();
            if (this.contexto.Produtos.Count() == 0)
            {
                List<Produto> produtos = new List<Produto>
                {
                    new Produto("Error 404", 59.99m),
                    new Produto("May the code", 59.99m),
                    new Produto("Rollback", 59.99m),
                    new Produto("Rest", 59.99m),
                };
                foreach (var produto in produtos)
                {
                    this.contexto.Produtos.Add(produto);
                    this.contexto.ItensCarrinho.Add(new ItemCarrinho(produto, 1));
                }
                this.contexto.SaveChanges();
            }
        }

        public List<Produto> GetProdutos()
        {
            return this.contexto.Produtos.ToList();
        }

        public List<ItemCarrinho> GetItensCarrinho()
        {
            return this.contexto.ItensCarrinho.Include("Produto").ToList();
        }

        public UpdateItemCarrinhoResponse UpdateItemCarrinho(ItemCarrinho itemCarrinho) {
            var itemCarrinhoDb = this.contexto.ItensCarrinho.Where((item) => item.Id == itemCarrinho.Id).SingleOrDefault();
            if(itemCarrinhoDb != null) {
                itemCarrinhoDb.AtualizarQuantidade(itemCarrinho.Quantidade);
                if(itemCarrinhoDb.Quantidade <= 0) {
                    this.contexto.ItensCarrinho.Remove(itemCarrinhoDb);
                }
                this.contexto.SaveChanges();
            }
            return new UpdateItemCarrinhoResponse(itemCarrinhoDb, new CarrinhoViewModel(GetItensCarrinho()));
        }

        public void AddItemCarrinho(int produtoId) {
            var produto = this.contexto.Produtos
                .Where((p) => p.Id == produtoId)
                .SingleOrDefault();
            
            if(produto != null) {
                var item = this.contexto.ItensCarrinho.Where((i) => i.Produto.Id == produtoId).Any();
                if(!item) {
                    this.contexto.ItensCarrinho.Add(new ItemCarrinho(produto, 1));
                    this.contexto.SaveChanges();
                }
            }
        }
    }
}