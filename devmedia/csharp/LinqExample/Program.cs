using System;
using System.IO;
using System.Linq;

namespace LinqExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var query = from arquivo in Directory.GetFiles("c:/windows/system32")
                        select arquivo;
            foreach (var arquivo in query)
            {
                Console.WriteLine(arquivo);
            }
            Console.ReadKey();
            var query2 = from arquivo in Directory.GetFiles("c:/windows/system32")
                         select new
                         {
                             NomeArquivo = Path.GetFileName(arquivo)
                         };
            foreach (var arquivo in query2)
            {
                Console.WriteLine(arquivo);
            }
            Console.ReadKey();
        }
    }
}
