using System;
using System.IO;
using System.Linq;

namespace LinqOrderByExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var query = from arquivo in Directory.GetFiles("c:/windows/system32")
                        let nomeArquivo = Path.GetFileName(arquivo)
                        let extensao = Path.GetExtension(arquivo)
                        orderby nomeArquivo, extensao descending
                        select new
                        {
                            NomeArquivo = nomeArquivo,
                            Extensao = extensao
                        };
            foreach (var item in query)
            {
                Console.WriteLine($"Nome do arquivo: {item.NomeArquivo}, Extensão: {item.Extensao}");
            }
            Console.ReadKey();
        }
    }
}
