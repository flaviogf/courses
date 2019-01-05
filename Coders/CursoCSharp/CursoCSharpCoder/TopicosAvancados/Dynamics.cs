using static System.Console;
using System.Dynamic;

namespace CursoCSharpCoder.TopicosAvancados
{
  public class Dynamics
  {
    [Exercicio(numero: 68, nome: "Dynamics")]
    public static void Executa()
    {
      dynamic valor = "teste";
      WriteLine(valor);
      valor = 10;
      valor++;
      WriteLine(valor);
      dynamic dinamico = new ExpandoObject();
      dinamico.teste = "OK";
      WriteLine(dinamico.teste);
    }
  }
}
