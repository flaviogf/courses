using static System.Console;
using System;
using System.IO;

namespace CursoCSharpCoder.Api
{
  public class Diretorios
  {
    [Exercicio(numero: 60, nome: "Diretorios")]
    public static void Executa()
    {
      var novoDir = "~/PastaCSharp".ParseHome();
      var novoDirDestino = "~/PastaCSharpDestino".ParseHome();
      var dirProjeto = Environment.CurrentDirectory;

      if (Directory.Exists(novoDir))
      {
        Directory.Delete(novoDir);
      }

      if (Directory.Exists(novoDirDestino))
      {
        Directory.Delete(novoDirDestino);
      }

      Directory.CreateDirectory(novoDir);
      WriteLine($"{novoDir} - {Directory.GetCreationTime(novoDir):dd/MM/yyyy - HH:mm:ss}");

      Directory.Move(novoDir, novoDirDestino);

      WriteLine($"{novoDirDestino} - {Directory.GetCreationTime(novoDirDestino):dd/MM/yyyy - HH:mm:ss}");

      WriteLine("Diretorios");
      foreach (var pasta in Directory.GetDirectories(dirProjeto))
      {
        WriteLine(pasta);
      }
    }
  }
}
