using static System.Console;
using System.IO;

namespace CursoCSharpCoder.Api
{
  public class ExemploDirectoryInfo
  {
    [Exercicio(numero: 61, nome: "Directory Info")]
    public static void Executa()
    {
      var home = "~".ParseHome();
      var info = new DirectoryInfo(home);
      WriteLine("Arquivos ".PadRight(100, '='));
      foreach(var arquivo in info.GetFiles())
      {
        WriteLine(arquivo);
      }
      WriteLine("Pastas ".PadRight(100, '='));
      foreach(var pasta in info.GetDirectories())
      {
        WriteLine(pasta);
      }
    }
  }
}
