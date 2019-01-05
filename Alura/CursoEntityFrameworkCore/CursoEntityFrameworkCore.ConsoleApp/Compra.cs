namespace CursoEntityFrameworkCore.ConsoleApp
{
    public class Compra
    {
        public int Id { get; set; }
        public decimal Preco { get; set; }
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
        public override string ToString() => $"Compra[Id={Id}, Preco={Preco}, Produto={Produto.Nome}, Quantidade={Quantidade}]";
    }
}
