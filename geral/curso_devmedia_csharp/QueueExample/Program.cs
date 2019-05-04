using System;
using System.Collections.Generic;

namespace QueueExample
{
    class Correntista
    {
        public string Agencia { get; set; }
        public string Nome { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var c1 = new Correntista { Agencia = "123", Nome = "Flávio" };
            var c2 = new Correntista { Agencia = "456", Nome = "Fernando" };
            var fila = new Queue<Correntista>();
            fila.Enqueue(c1);
            fila.Enqueue(c2);
            Console.WriteLine("Correntistas na fila");
            foreach (var correntista in fila)
            {
                Console.WriteLine($"AGENCIA {correntista.Agencia} - NOME {correntista.Nome}");
            }
            while (fila.Count > 0)
            {
                Console.WriteLine("Pressiona um tecla para chamar um correntista");
                Console.ReadKey();
                Console.Beep();
                Console.WriteLine($"Correntista {fila.Dequeue().Nome} chamado");
            }
            Console.WriteLine("Todos os correntistas foram atendidos");
            Console.ReadKey();
        }
    }
}
