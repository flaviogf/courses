using static System.Console;
using System.IO;

namespace CursoCSharpCoder.Api
{
  public class ExemploFileInfo
  {
    private static void ExcluiSeExiste(params string[] arquivos)
    {
      foreach (var arquivo in arquivos)
      {
        var info = new FileInfo(arquivo);
        if (info.Exists) info.Delete();
      }
    }

    [Exercicio(numero: 59, nome: "Exemplo File Info")]
    public static void Executa()
    {
      var origem = "~/original.txt".ParseHome();
      var copia = "~/copia.txt".ParseHome();
      var destino = "~/destino.txt".ParseHome();

      ExcluiSeExiste(origem, copia, destino);

      using(var sw = File.AppendText(origem))
      {
        sw.WriteLine("Arquivo original!!!");
      }

      var arquivoOrigem = new FileInfo(origem);
      WriteLine(arquivoOrigem.IsReadOnly);
      WriteLine(arquivoOrigem.FullName);
      WriteLine(arquivoOrigem.Extension);

      arquivoOrigem.CopyTo(copia);
      arquivoOrigem.MoveTo(destino);
    }
  }
}
