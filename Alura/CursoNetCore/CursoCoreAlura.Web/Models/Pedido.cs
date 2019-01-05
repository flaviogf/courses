using System.Collections.Generic;
using System.Linq;

namespace CursoCoreAlura.Web.Models
{
    public class Pedido
    {
        public int Id { get; set; }

        public IList<ItemPedido> ItensPedido { get; set; } = new List<ItemPedido>();

        public Cadastro Cadastro { get; set; }

        public decimal Valor => ItensPedido.Sum(it => it.PrecoUnitario * it.Quantidade);

        public Pedido()
        {
            Cadastro = new Cadastro();
        }

        public void Adiciona(ItemPedido itemPedido)
        {
            var itemPedidoDb = ItensPedido.SingleOrDefault(it => it.Produto.Id == itemPedido.Produto.Id);
            if (itemPedidoDb != null) return;
            itemPedido.Pedido = this;
            ItensPedido.Add(itemPedido);
        }
    }
}
