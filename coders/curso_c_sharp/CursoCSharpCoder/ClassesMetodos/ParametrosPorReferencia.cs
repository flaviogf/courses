using static System.Console;

namespace CursoCSharpCoder.ClassesMetodos
{
  public class ParametrosPorReferencia
  {
    public static void AlteraRef(ref int numero)
    {
      numero += 10;
    }

    public static void AlteraOut(out int numero1, out int numero2)
    {
      numero1 = 20;
      numero2 = 30;
    }

    [Exercicio(numero: 34, nome: "Parametros Por Referencia")]
    public static void Executa()
    {
      var numero1 = 1;
      AlteraRef(ref numero1);
      WriteLine(numero1);

      AlteraOut(out var numero2, out var numero3);
      WriteLine("{0} - {1}", numero2, numero3);
    }
  }
}
