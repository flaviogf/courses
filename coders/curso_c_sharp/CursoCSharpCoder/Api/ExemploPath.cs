using static System.Console;
using static System.IO.Path;
using static System.Environment;

namespace CursoCSharpCoder.Api
{
  public class ExemploPath
  {
    [Exercicio(numero: 62, nome: "Exemplo Path")]
    public static void Executa()
    {
      WriteLine(GetDirectoryName(CurrentDirectory));
      WriteLine(GetPathRoot(CurrentDirectory));
      WriteLine(HasExtension(CurrentDirectory));
      WriteLine(GetFileName(CurrentDirectory));
    }
  }
}
