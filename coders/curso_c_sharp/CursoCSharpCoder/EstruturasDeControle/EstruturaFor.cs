using static System.Console;

namespace CursoCSharpCoder.EstruturasDeControle
{
  public class EstruturaFor
  {
    [Exercicio(numero: 20, nome: "Estutura For")]
    public static void Executa()
    {
      Write("Repeticao: ");
      int.TryParse(ReadLine(), out var repeticao);
      for (var i = 0; i < repeticao; i++)
      {
        WriteLine("{0} HELLO", i + 1);
      }
    }
  }
}
