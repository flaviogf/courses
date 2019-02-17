using System;

namespace CarreiraCSharpAlura.CalculoPoupancaWhile
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var contador = default(int);
            var poupanca = 1000m;
            while (contador <= 12)
            {
                poupanca *= 1.0036m;
                contador++;
            }

            Console.WriteLine("Valor final {0:C}", poupanca);
        }
    }
}