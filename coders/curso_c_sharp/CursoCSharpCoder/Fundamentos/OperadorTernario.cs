using static System.Console;

namespace CursoCSharpCoder.Fundamentos
{
  public class OperadorTernario
  {
    [Exercicio(numero: 15, nome: "Operador Ternario")]
    public static void Executa()
    {
      Write("Nota: ");
      if (!decimal.TryParse(ReadLine(), out var nota))return;
      WriteLine(nota > 7 ? "Aprovado" : "Reprovado");
    }
  }
}
