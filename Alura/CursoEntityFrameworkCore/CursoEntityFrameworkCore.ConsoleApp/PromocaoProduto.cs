namespace CursoEntityFrameworkCore.ConsoleApp
{
    public class PromocaoProduto
    {
        public int PromocaoId { get; set; }
        public Promocao Promocao { get; set; }
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
    }
}
