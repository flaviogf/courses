using System;

namespace CarreiraCSharpAlura.CriandoVariavies
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int idade = 21;
            Console.WriteLine($"Idade: {idade}");
            idade = 21 + 10;
            Console.WriteLine("Idade: {0}", idade);
        }
    }
}