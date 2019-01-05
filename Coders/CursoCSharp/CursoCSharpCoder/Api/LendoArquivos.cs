using static System.Console;
using System.IO;

namespace CursoCSharpCoder.Api
{
  public class LendoArquivos
  {
    [Exercicio(numero: 58, nome: "Lendo Arquivos")]
    public static void Executa()
    {
      var arquivo = "~/lendo_arquivo.txt".ParseHome();
      using(var sw = File.AppendText(arquivo))
      {
        sw.WriteLine("Nome;Quantidade;Preco");
        sw.WriteLine("Maca,2,10.99");
      }
      using(var sr = new StreamReader(arquivo))
      {
        WriteLine(sr.ReadToEnd());
      }
    }
  }
}
