using System.Linq;
using CursoCoreAlura.Web.Infra;
using CursoCoreAlura.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace CursoCoreAlura.Web.Repositories
{
    public interface IPedidoRepository
    {
        Pedido Insere(string codigoProduto);
        Pedido Busca();
        Pedido Atualiza(ItemPedido itemPedido);
    }

    public class PedidoRepository : IPedidoRepository
    {
        private readonly ApplicationContext _applicationContext;

        private readonly IHttpContextAccessor _contextAccessor;

        private int IdPedido
        {
            get => _contextAccessor.HttpContext.Session.GetInt32("idPedido") ?? 0;
            set => _contextAccessor.HttpContext.Session.SetInt32("idPedido", value);
        }

        public PedidoRepository(IHttpContextAccessor contextAccessor, ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
            _contextAccessor = contextAccessor;
        }

        public Pedido Insere(string codigoProduto)
        {
            var produto = _applicationContext.Produto.Single(it => it.Codigo == codigoProduto);
            var pedido = _applicationContext.Pedido
                .Include(it => it.ItensPedido)
                .ThenInclude(it => it.Produto)
                .SingleOrDefault(it => it.Id == IdPedido);

            if (pedido == null)
            {
                pedido = new Pedido();
                _applicationContext.Pedido.Add(pedido);
                _applicationContext.SaveChanges();
                IdPedido = pedido.Id;
            }

            var itemPedido = new ItemPedido(produto);
            pedido.Adiciona(itemPedido);
            _applicationContext.SaveChanges();
            return pedido;
        }

        public Pedido Busca()
        {
            return _applicationContext.Pedido
                       .Include(it => it.ItensPedido)
                       .ThenInclude(it => it.Produto)
                       .SingleOrDefault(it => it.Id == IdPedido) ?? new Pedido();
        }

        public Pedido Atualiza(ItemPedido itemPedido)
        {
            var pedido = Busca();
            var itemPedidoDb = pedido.ItensPedido.First(it => it.Id == itemPedido.Id);
            itemPedidoDb.Quantidade = itemPedido.Quantidade;
            _applicationContext.SaveChanges();
            return pedido;
        }
    }
}
