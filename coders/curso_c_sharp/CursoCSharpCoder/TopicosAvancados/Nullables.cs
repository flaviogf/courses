using static System.Console;
using System;

namespace CursoCSharpCoder.TopicosAvancados
{
  public class Nullables
  {
    [Exercicio(numero: 67, nome: "Nullables")]
    public static void Executa()
    {
      Nullable<int> valor1 = null;
      int? valor2 = null;
      WriteLine(valor2 ?? 0);
      WriteLine(valor1 ?? 0);
      valor1 = 1;
      if (valor1.HasValue)
      {
        WriteLine(valor1.Value);
      }
    }
  }
}
