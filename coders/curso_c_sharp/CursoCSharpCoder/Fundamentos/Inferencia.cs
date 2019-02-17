using static System.Console;

namespace CursoCSharpCoder.Fundamentos
{
  public class Inferencia
  {
    [Exercicio(numero: 4, nome: "Inferencia")]
    public static void Executa()
    {
      var nome = "flavio";
      // var nome;
      // nome = "flavio";
      string texto;
      texto = "Usuario";
      var idade = 21;
      WriteLine($"{texto} {nome} {idade}");
    }
  }
}
