using System;
using System.IO;
using System.Linq;

namespace LinqGroupByCompostoExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var query = from arquivo in Directory.GetFiles("C:/Windows/Microsoft.NET/Framework/v4.0.30319", "*", SearchOption.AllDirectories)
                        let infoArquivo = new FileInfo(arquivo)
                        group infoArquivo by new
                        {
                            Pasta = infoArquivo.DirectoryName,
                            Extensao = infoArquivo.Extension.ToUpper()
                        }
                        into infoArquivosPorPasta
                        let tamanhoArquivo = infoArquivosPorPasta.Sum((item) => item.Length)
                        orderby infoArquivosPorPasta.Key.Pasta, infoArquivosPorPasta.Key.Extensao, tamanhoArquivo descending
                        select new
                        {
                            infoArquivosPorPasta.Key.Pasta,
                            infoArquivosPorPasta.Key.Extensao,
                            NumeroArquivo = infoArquivosPorPasta.Count(),
                            tamanho = tamanhoArquivo
                        };
            foreach (var item in query)
            {
                Console.WriteLine($"{item.Pasta} - {item.Extensao} - {item.NumeroArquivo} - {item.tamanho}");
            }
            Console.ReadKey();
        }
    }
}
