using System;

namespace CarreiraCSharpAlura.CriandoVariaviesDouble
{
    delegate double OperacaoDelegate(double x, double y);

    public class Program
    {
        public static void Main(string[] args)
        {
            double largura = 3.2;
            Console.WriteLine(largura);

            largura = 3.2 * 10;

            Console.WriteLine(largura);

            largura = 3.2 + 4.3;

            Console.WriteLine($"{largura:F5}");

            OperacaoDelegate soma = (x, y) => x + y;
            
            Console.WriteLine(soma(largura, largura * 2));
        }
    }
}