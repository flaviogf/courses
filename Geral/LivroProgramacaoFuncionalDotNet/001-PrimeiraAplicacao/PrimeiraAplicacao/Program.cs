using System;

namespace PrimeiraAplicacao
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var calc = new Calculadora();
            Console.WriteLine(calc.SomaQuadradoDezPrimeirosNumeros());
        }
    }
}
