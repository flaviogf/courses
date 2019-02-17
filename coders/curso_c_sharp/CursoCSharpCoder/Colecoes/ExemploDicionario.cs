using System.Collections.Generic;
using static System.Console;

namespace CursoCSharpCoder.Colecoes
{
  public class ExemploDicionario
  {
    [Exercicio(numero: 43, nome: "Dicionario")]
    public static void Executa()
    {
      var filmes = new Dictionary<int, string>
        {
          [2000] = "Teste 1",
          [2001] = "Teste 2"
        };
      WriteLine(filmes.ContainsKey(2000));
      foreach (var (ano, nome) in filmes)
      {
        WriteLine("{0} - {1}", ano, nome);
      }
    }
  }
}
