using System;
using System.IO;
using System.Text;

namespace CarreiraCSharpAlura.Arquivos
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Exemplo001();
            // Exemplo002();
            // Exemplo003();
            // Exemplo004();
            Exemplo005();
        }

        private static void Exemplo005()
        {
            using (var console = Console.OpenStandardInput())
            using (var reader = new StreamReader(console))
            using (var fs = new FileStream("arquivo_002.txt", FileMode.Create))
            using (var writer = new StreamWriter(fs))
            {
                while (true)
                {
                    var texto = reader.ReadLine();
                    writer.WriteLine(texto);
                    writer.Flush();
                }
            }
        }

        private static void Exemplo004()
        {
            using (var fs = new FileStream("arquivo_001.txt", FileMode.Create))
            using (var writer = new StreamWriter(fs))
            {
                for (var i = 1; i <= 10; i++)
                {
                    var linha = $"Linha: {i}";
                    writer.WriteLine(linha);
                    writer.Flush();
                    Console.WriteLine($"{linha} escrita no arquivo");
                    Console.WriteLine("Pressione enter para continuar");
                    Console.ReadLine();
                }
            }
        }

        private static void Exemplo003()
        {
            using (var fileStream = new FileStream("conta_exportadas_001.csv", FileMode.Create))
            using (var writer = new StreamWriter(fileStream))
            {
                writer.WriteLine("111, 2222, 50.00, Fernando");
            }
            Console.WriteLine("Contas exportadas com sucesso");
        }

        private static void Exemplo002()
        {
            using (var fileStream = new FileStream("contas.txt", FileMode.Open))
            {
                using (var streamReader = new StreamReader(fileStream))
                {
                    while (!streamReader.EndOfStream)
                    {
                        var linha = streamReader.ReadLine().Split(',');
                        var agencia = linha[0];
                        var numero = linha[1];
                        var saldo = decimal.Parse(linha[2].Replace('.', ','));
                        var titular = linha[3];
                        var conta = new Conta(agencia, numero, saldo, titular);
                        Console.WriteLine(conta);
                    }
                }
            }
        }

        private static void Exemplo001()
        {
            var buffer = new byte[1024];

            using (var stream = new FileStream("contas.txt", FileMode.Open))
            {
                var bytesLidos = stream.Read(buffer, 0, 1024);

                while (bytesLidos != 0)
                {
                    var texto = Encoding.UTF8.GetString(buffer, 0, bytesLidos);

                    Console.WriteLine(texto);

                    bytesLidos = stream.Read(buffer, 0, 1024);

                    // foreach (var it in buffer)
                    // {
                    //     Console.WriteLine(it);
                    // }
                }
            }
        }
    }
}
