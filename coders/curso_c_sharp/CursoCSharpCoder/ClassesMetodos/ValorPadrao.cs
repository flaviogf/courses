using static System.Console;

namespace CursoCSharpCoder.ClassesMetodos
{
  public class ValorPadrao
  {
    public static int Soma(int a = 1, int b = 1)
    {
      return a + b;
    }

    [Exercicio(numero: 35, nome: "Valor Padrão")]
    public static void Executa()
    {
      WriteLine(Soma(10, 10));
      WriteLine(Soma(10));
      WriteLine(Soma(b: 10));
      WriteLine(Soma());
    }
  }
}
