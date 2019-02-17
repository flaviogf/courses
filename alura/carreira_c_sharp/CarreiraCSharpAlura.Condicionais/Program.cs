using System;

namespace CarreiraCSharpAlura.Condicionais
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Idade: ");
            var entradaIdade = Console.ReadLine();
            Console.WriteLine("Acompanhantes");
            var entradaAcompanhantes = Console.ReadLine();
            if (!int.TryParse(entradaAcompanhantes, out var acompanhantes)) return;
            if (!int.TryParse(entradaIdade, out var idade)) return;
            if (idade >= 18)
            {
                Console.WriteLine("Liberado");
            }
            else if (acompanhantes > 2)
            {
                Console.WriteLine("Liberado com acompanhantes");
            }
            else
            {
                Console.WriteLine("Barrado");
            }
        }
    }
}