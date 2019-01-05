using static System.Console;

namespace CursoCSharpCoder.ClassesMetodos
{
  public class Params
  {
    public static void Recepciona(params string[] nomes)
    {
      foreach (var nome in nomes)
      {
        WriteLine("OLA {0}", nome);
      }
    }

    [Exercicio(numero: 27, nome: "Parametros Variaveis - Params")]
    public static void Executa()
    {
      Recepciona("Teste 1", "Teste 2", "Teste 3");
    }
  }
}
