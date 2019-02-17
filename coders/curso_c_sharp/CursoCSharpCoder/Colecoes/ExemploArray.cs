using static System.Console;
using System.Globalization;
using System.Linq;

namespace CursoCSharpCoder.Colecoes
{
  public class ExemploArray
  {
    [Exercicio(numero: 36, nome: "Array")]
    public static void Executa()
    {
      var turmaA = new string[] { "Teste 1", "Teste 2" };
      foreach (var aluno in turmaA)
      {
        WriteLine(aluno);
      }
      var turmaB = new string[5];
      turmaB[0] = "Teste 3";
      turmaB[1] = "Teste 4";
      turmaB[2] = "Teste 5";
      turmaB[3] = "Teste 6";
      turmaB[4] = "Teste 7";
      foreach (var aluno in turmaB)
      {
        WriteLine(aluno);
      }
      var notas = new decimal[] { 10M, 8M, 9M };
      WriteLine(notas.Average().ToString("F2", CultureInfo.CreateSpecificCulture("en-US")));
    }
  }
}
