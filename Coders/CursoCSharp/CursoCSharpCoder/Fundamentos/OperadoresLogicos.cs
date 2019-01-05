using static System.Console;

namespace CursoCSharpCoder.Fundamentos
{
  public class OperadoresLogicos
  {
    [Exercicio(numero: 12, nome: "Operadores Logicos")]
    public static void Executa()
    {
      WriteLine(false && true);
      WriteLine(true && true);
      WriteLine(false || false);
      WriteLine(false || true);
      WriteLine(true ^ true);
      WriteLine(true ^ false);
      WriteLine(!true);
      WriteLine(!false);
    }
  }
}
