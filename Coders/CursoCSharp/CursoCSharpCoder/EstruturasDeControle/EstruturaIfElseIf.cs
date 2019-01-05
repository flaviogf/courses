using static System.Console;

namespace CursoCSharpCoder.EstruturasDeControle
{
  public class EstruturaIfElseIf
  {
    [Exercicio(numero: 18, nome: "Estrutura If Else If")]
    public static void Executa()
    {
      Write("Nota: ");
      decimal.TryParse(ReadLine(), out var nota);
      if (nota >= 8)
      {
        WriteLine("Quadro de honra");
      }
      else if (nota >= 6)
      {
        WriteLine("Aprovado");
      }
      else
      {
        WriteLine("Reprovado");
      }
    }
  }
}
