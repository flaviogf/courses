using System;
using System.Collections.Generic;

namespace CursoEntityFrameworkCore.ConsoleApp
{
    public class Promocao
    {
        public int Id { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime DataFim { get; set; }

        public IList<PromocaoProduto> Produtos { get; set; } = new List<PromocaoProduto>();

        public void Adiciona(Produto produto)
        {
            Produtos.Add(new PromocaoProduto() { Produto = produto });
        }
    }
}
