using static System.Console;

namespace CursoCSharpCoder.Fundamentos
{
  public class OperadoresRelacionais
  {
    [Exercicio(numero: 11, nome: "Operadores Relacionais")]
    public static void Executa()
    {
      WriteLine(2 > 1);
      WriteLine(1 < 2);
      WriteLine(1 <= 2);
      WriteLine(1 >= 1);
      WriteLine(1 == 1);
      WriteLine(1 != 2);
    }
  }
}
