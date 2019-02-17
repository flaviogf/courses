using System.Collections.Generic;
using static System.Console;

namespace CursoCSharpCoder.Colecoes
{
  class Produto
  {
    public string Nome { get; set; }
    public decimal Preco { get; set; }

    public override bool Equals(object obj)
    {
      var produto = (Produto)obj;
      return produto != null &&
        Nome == produto.Nome &&
        Preco == produto.Preco;
    }

    public override int GetHashCode()
    {
      return Nome.Length;
    }

    public override string ToString()
    {
      return $"Nome: {Nome} - Preco: {Preco:C}";
    }
  }

  public class ExemploList
  {
    [Exercicio(numero: 37, nome: "List")]
    public static void Executa()
    {
      var livro = new Produto { Nome = "Game of Thrones", Preco = 49.9M };
      var carrinho = new List<Produto>();
      carrinho.Add(livro);

      var combo = new List<Produto>
      {
        new Produto { Nome = "Camisa", Preco = 29.9M },
        new Produto { Nome = "Poste", Preco = 99.9M }
      };

      carrinho.AddRange(combo);

      carrinho.ForEach(WriteLine);

      WriteLine(carrinho.Count);
    }
  }
}
