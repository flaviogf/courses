using static System.Console;

namespace CursoCSharpCoder.Fundamentos
{
  public class OperadoresUnarios
  {
    [Exercicio(numero: 14, nome: "Operadores Unarios")]
    public static void Executa()
    {
      var valorNegativo = -1;
      var numero1 = 2;
      var numero2 = 3;

      WriteLine(-valorNegativo);
      WriteLine(numero1++);
      WriteLine(--numero2);
      WriteLine(numero1-- == ++numero2);
    }
  }
}
