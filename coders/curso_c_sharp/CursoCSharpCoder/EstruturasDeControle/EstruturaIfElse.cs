using static System.Console;

namespace CursoCSharpCoder.EstruturasDeControle
{
  public class EstruturaIfElse
  {
    [Exercicio(numero: 17, nome: "Estrutura If Else")]
    public static void Executa()
    {
      Write("Nota: ");
      decimal.TryParse(ReadLine(), out var nota);
      if (nota >= 7)
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
