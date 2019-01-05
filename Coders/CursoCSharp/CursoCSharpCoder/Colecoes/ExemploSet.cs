using System.Collections.Generic;
using static System.Console;

namespace CursoCSharpCoder.Colecoes
{
  public class ExemploSet
  {
    [Exercicio(numero: 39, nome: "Set")]
    public static void Executa()
    {
      var carrinho = new HashSet<Produto>
      {
        new Produto { Nome = "Teste 1", Preco = 99.99M },
        new Produto { Nome = "Teste 2", Preco = 100.00M }
      };
      var produto = new Produto { Nome = "Teste 3", Preco = 5.50M };
      carrinho.Add(produto);
      carrinho.Add(produto);
      carrinho.Add(produto);
      var combo = new HashSet<Produto>
      {
        new Produto { Nome = "Teste 4", Preco = 55.00M },
        new Produto { Nome = "Teste 5", Preco = 56.56M }
      };
      carrinho.UnionWith(combo);
      foreach (var item in carrinho)
      {
        WriteLine(item);
      }
    }
  }
}
