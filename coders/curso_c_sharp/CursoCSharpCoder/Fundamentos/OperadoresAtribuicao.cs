using static System.Console;

namespace CursoCSharpCoder.Fundamentos
{
  public class OperadoresAtribuicao
  {
    [Exercicio(numero: 13, nome: "Operadores Atribuicao")]
    public static void Executa()
    {
      var total = 50;
      total += 50;
      total *= 2;
      total /= 2;
      total -= 50;
      WriteLine(total);
    }
  }
}
