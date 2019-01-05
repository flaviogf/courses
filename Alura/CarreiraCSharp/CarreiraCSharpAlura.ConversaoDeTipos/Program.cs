using System;

namespace CarreiraCSharpAlura.ConversaoDeTipos
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int ano = 2000;
            double ano2 = ano + 1;
            Console.WriteLine(ano2);
            int ano3 = (int) ano2;
            Console.WriteLine(ano3);
        }
    }
}