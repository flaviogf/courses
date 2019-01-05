using static System.Console;
using static CursoCSharpCoder.MetodosFuncoes.Calculadora;

namespace CursoCSharpCoder.MetodosFuncoes
{
  public delegate int Operacao(int x, int y);

  public class Calculadora
  {
    public static string Calcula(Operacao op, int x, int y)
    {
      var resultado = op(x, y);
      return $"Resultado {resultado}";
    }
  }

  public class DelegatesComoParametros
  {
    [Exercicio(numero: 53, nome: "Delegates como Parametros")]
    public static void Executa()
    {
      WriteLine(Calcula((x, y) => x + y, 2, 2));
      WriteLine(Calcula((x, y) => x * y, 2, 2));
    }
  }
}
