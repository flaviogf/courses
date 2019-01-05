using System;

namespace CarreiraCSharpAlura.CalculoPoupancaFor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var poupanca = 1000m;
            for (var i = 0; i <= 12; i++)
            {
                poupanca *= 1.0036m;
            }

            Console.WriteLine("Valor fina {0:C}", poupanca);
        }
    }
}