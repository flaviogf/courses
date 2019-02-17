using System.Globalization;
using static System.Console;

namespace CursoCSharpCoder.Fundamentos
{
  public class FormatandoNumero
  {
    [Exercicio(numero: 8, nome: "Formatando Numeros")]
    public static void Executa()
    {
      var valor = 50.99;
      WriteLine($"{valor:F1}");
      WriteLine($"{0.5:P}");
      WriteLine($"{valor:#.##}");
      WriteLine($"{valor:C}");
      WriteLine(valor.ToString("C", CultureInfo.CreateSpecificCulture("en-US")));
    }
  }
}
