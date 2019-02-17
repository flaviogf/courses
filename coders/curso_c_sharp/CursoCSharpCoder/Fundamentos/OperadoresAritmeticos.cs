using static System.Console;
using static System.Math;

namespace CursoCSharpCoder
{
  public class OperadoresAritmeticos
  {
    [Exercicio(numero: 10, nome: "Operadores Aritmeticos")]
    public static void Executa()
    {
      WriteLine(2 + 2);
      WriteLine(2 * 2);
      WriteLine(8 / 2);
      WriteLine(Pow(2, 2));
    }
  }
}
