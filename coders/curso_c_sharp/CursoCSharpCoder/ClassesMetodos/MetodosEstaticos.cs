using static CursoCSharpCoder.ClassesMetodos.CalculadoraEstatica;
using static System.Console;
using System.Globalization;

namespace CursoCSharpCoder.ClassesMetodos
{
  static class CalculadoraEstatica
  {
    public static int Soma(int a, int b)
    {
      return a + b;
    }

    public static decimal Soma(this decimal obj, decimal a)
    {
      return obj + a;
    }
  }

  public class MetodosEstaticos
  {

    [Exercicio(numero: 25, nome: "Metodos Estaticos")]
    public static void Executa()
    {
      Write("Inteiros: ");
      WriteLine(Soma(2, 2).ToString("C", CultureInfo.CreateSpecificCulture("en-US")));
      Write("Decimais: ");
      WriteLine(2.3M.Soma(2.4M).ToString("C"));
    }
  }
}
