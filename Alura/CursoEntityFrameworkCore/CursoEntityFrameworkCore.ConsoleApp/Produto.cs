using System.Collections.Generic;

namespace CursoEntityFrameworkCore.ConsoleApp
{
    public class Produto
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Categoria { get; set; }

        public decimal Preco { get; set; }

        public string Unidade { get; set; }

        public IList<PromocaoProduto> Promocoes { get; set; }

        public override string ToString() => $"Produto[Id={Id}, Nome={Nome}, Categoria={Categoria}, Preco={Preco}, Unidade={Unidade}]";
    }
}
