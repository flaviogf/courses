using static System.Console;

namespace CursoCSharpCoder.EstruturasDeControle
{
  public class EstruturaForEach
  {
    [Exercicio(numero: 21, nome: "Estrutura ForEach")]
    public static void Executa()
    {
      var palavra = "HELLO";
      foreach (var letra in palavra)
      {
        WriteLine("Letra {0}", letra);
      }
    }
  }
}
