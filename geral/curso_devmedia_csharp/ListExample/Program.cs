using System;
using System.Collections.Generic;
using System.Linq;

namespace ListExample
{
    class Cliente
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public override string ToString()
        {
            return $"NOME: {Nome}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var c1 = new Cliente { Nome = "Flávio", CPF = "123" };
            var c2 = new Cliente { Nome = "Fernando", CPF = "456" };
            var lista = new List<Cliente> { c1, c2 };
            foreach (var item in lista)
            {
                Console.WriteLine(item);
            }
            var cliente = lista.FirstOrDefault((c) => c.CPF == "123");
            Console.WriteLine(cliente);
            Console.ReadKey();
        }
    }
}
