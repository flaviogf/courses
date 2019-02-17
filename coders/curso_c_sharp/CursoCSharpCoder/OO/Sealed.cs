using static System.Console;

namespace CursoCSharpCoder.OO
{
  sealed class SemFilho
  {

  }

  // class Filho: SemFilho
  // {
    
  // }

  public class Sealed
  {
    [Exercicio(numero: 49, nome: "Sealed")]
    public static void Executa()
    {
        WriteLine(new SemFilho());
    }
  }
}
