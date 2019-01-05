using System;

namespace CarreiraCSharpAlura.CaracteresTextos
{
    public class Program
    {
        public static void Main(string[] args)
        {
            char primeiraLetra = 'a';
            Console.WriteLine(primeiraLetra);
            Console.WriteLine((int) primeiraLetra);
            string cursos = @"
                            - .Net
                            - Java
                            - JavaScript
                            ";
            Console.Write(cursos);
        }
    }
}