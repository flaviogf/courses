using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace CursoCSharpCoder.EstruturasDeControle
{
  public class EstruturaWhile
  {
    [Exercicio(numero: 19, nome: "Estrutura While")]
    public static void Executa()
    {
      var notas = new List<decimal>();
      while (true)
      {
        Write("Nota: ");
        if (!decimal.TryParse(ReadLine(), out var nota))break;
        notas.Add(nota);
      }
      WriteLine("Média: {0}", notas.Average());
    }
  }
}
