using System;
using System.IO;
using System.Linq;

namespace LinqGroupByExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var query = from arquivo in Directory.GetFiles("c:/windows/system32")
                        let infoArquivo = new FileInfo(arquivo)
                        group infoArquivo by infoArquivo.Extension into grupo
                        let extensao = grupo.Key
                        orderby extensao
                        select new
                        {
                            Extensao = extensao,
                            NumeroArquivos = grupo.Count(),
                            TamanhoArquivos = grupo.Sum((item) => item.Length / 1024M),
                            MediaTamanhoArquivos = grupo.Average((item) => item.Length / 1204M),
                            TamanhoMaiorArquivo = grupo.Max((item) => item.Length),
                            TamanhoiMenorArquivo = grupo.Min((item) => item.Length)
                        };
            foreach (var item in query)
            {
                Console.WriteLine($"Grupo {item.Extensao}");
                Console.WriteLine($"Numero de Arquivos: {item.NumeroArquivos} - Tamanho Total: {item.TamanhoArquivos} - Media Tamanho: {item.MediaTamanhoArquivos} - Maior arquivo: {item.TamanhoMaiorArquivo} - Menor arquivo: {item.TamanhoiMenorArquivo}");
            }
            Console.ReadKey();
        }
    }
}
