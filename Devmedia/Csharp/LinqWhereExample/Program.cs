using System;
using System.IO;
using System.Linq;

namespace LinqWhereExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var query = from arquivo in Directory.GetFiles("c:/windows/system32")
                        let infoArquivo = new FileInfo(arquivo)
                        let tamanhoArquivo = infoArquivo.Length / 1024M / 1024M
                        where tamanhoArquivo > 1M && infoArquivo.Extension.ToUpper() == ".EXE"
                        select new
                        {
                            NomeArquivo = infoArquivo.Name,
                            TamanhoArquivo = tamanhoArquivo
                        };
            foreach (var item in query)
            {
                Console.WriteLine($"Arquivo: {item.NomeArquivo} - Tamanho: {item.TamanhoArquivo}");
            }
            Console.ReadKey();
        }
    }
}
