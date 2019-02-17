using System;

namespace CarreiraCSharpAlura.CalculoPoupancaLongoPrazo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var poupanca = 1000m;
            var juros = 1.0036m;
            for (var ano = 0; ano <= 5; ano++)
            {
                for (var mes = 0; mes <= 12; mes++)
                {
                    poupanca *= juros;
                }

                juros += 0.001m;
            }

            for (var linha = 0; linha <= 10; linha++)
            {
                for (var coluna = 0; coluna <= linha; coluna++)
                {
                    Console.Write('*');
                }

                Console.WriteLine();
            }

            Console.WriteLine("Valor final {0:C}", poupanca);
        }
    }
}