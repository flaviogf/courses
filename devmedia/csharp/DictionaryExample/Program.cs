using System;
using System.Collections.Generic;
using System.Linq;

namespace DictionaryExample
{
    class Pedido
    {
        public string Cliente { get; set; }
        public double Valor { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var pedidos = new Dictionary<int, Pedido>
            {
                [1] = new Pedido { Cliente = "Flávio", Valor = 250.99 },
                [2] = new Pedido { Cliente = "Fernando", Valor = 300.99 }
            };
            Console.WriteLine("Nome dos clientes que realizarem pedidos:");
            foreach (var pedido in pedidos.Values)
            {
                Console.WriteLine(pedido.Cliente);
            }
            Console.WriteLine("Pedidos realizados:");
            foreach (var pedidos2 in pedidos)
            {
                Console.WriteLine($"Código {pedidos2.Key} - Valor R$ {pedidos2.Value.Valor}");
            }
            var somaTotal = pedidos.Sum((pedido) => pedido.Value.Valor);
            Console.WriteLine($"Valor total dos pedidos: R$ {somaTotal}");
            Console.ReadKey();
        }
    }
}
