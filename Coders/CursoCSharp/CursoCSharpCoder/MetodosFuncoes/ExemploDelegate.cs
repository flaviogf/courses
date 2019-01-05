using static System.Console;

namespace CursoCSharpCoder.MetodosFuncoes
{
  delegate double OperacaoDelegate(double x, double y);

  public class ExemploDelegate
  {
    private static double Multiplicacao(double x, double y)
    {
      return x * y;
    }

    [Exercicio(numero: 51, nome: "Delegate")]
    public static void Executa()
    {
      OperacaoDelegate div = delegate(double x, double y)
      {
        return x / y;
      };
      OperacaoDelegate soma = (x, y) => x + y;
      OperacaoDelegate mult = Multiplicacao;
      WriteLine(div(10, 10));
      WriteLine(soma(10, 10));
      WriteLine(mult(10, 10));
    }
  }
}
