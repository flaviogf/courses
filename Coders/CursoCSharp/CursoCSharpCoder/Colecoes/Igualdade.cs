using System.Collections.Generic;
using static System.Console;

namespace CursoCSharpCoder.Colecoes
{
  public class Igualdade
  {
    [Exercicio(numero: 41, nome: "Igualdade")]
    public static void Executa()
    {
      var prod1 = new Produto { Nome = "Teste 1", Preco = 100M };
      var prod2 = new Produto { Nome = "Teste 1", Preco = 100M };
      var produtos = new HashSet<Produto>
      {
        prod1,
        prod2
      };
      WriteLine(produtos.Count);
      foreach (var produto in produtos)
      {
        WriteLine(produto);
      }
    }
  }
}
