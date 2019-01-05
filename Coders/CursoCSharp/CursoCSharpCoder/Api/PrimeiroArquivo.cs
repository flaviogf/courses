using static System.Console;
using System;
using System.IO;

namespace CursoCSharpCoder.Api
{
  public static class ExtensaoString
  {
    public static string ParseHome(this string obj)
    {
      var home = Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%");
      return obj.Replace("~", home);
    }
  }

  public class PrimeiroArquivo
  {
    [Exercicio(numero: 57, nome: "Primeiro Arquivo")]
    public static void Executa()
    {
      var arquivo = @"~/primeiro_arquivo.txt".ParseHome();
      if (!File.Exists(arquivo))
      {
        using(var sw = File.CreateText(arquivo))
        {
          sw.WriteLine("Este é");
          sw.WriteLine("Nosso primeiro");
          sw.WriteLine("Arquivo!!");
        }
      }
      else
      {
        using(var sw = File.AppendText(arquivo))
        {
          sw.WriteLine("Arquivo Ja criado");
          sw.WriteLine("Nova linha adicionada!");
        }
      }

      WriteLine(arquivo);
    }
  }
}
