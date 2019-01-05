namespace CursoCoreAlura.Web.Models
{
    public class ItemPedido
    {
        public int Id { get; set; }

        public Pedido Pedido { get; set; }

        public Produto Produto { get; set; }

        private int _quantidade = 1;

        public int Quantidade
        {
            get => _quantidade;
            set => _quantidade = value >= 0 ? value : 0;
        }

        public decimal PrecoUnitario { get; set; }

        public decimal SubTotal => Quantidade * PrecoUnitario;

        public ItemPedido()
        {
        }

        public ItemPedido(Produto produto)
        {
            Produto = produto;
            PrecoUnitario = produto.Preco;
        }
    }
}
