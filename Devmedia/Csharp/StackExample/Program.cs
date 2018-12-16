using System;
using System.Collections.Generic;

namespace StackExample
{
    class Documento
    {
        public string Nome { get; set; }
        public string Tipo { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var doc1 = new Documento { Nome = "Artigo", Tipo = "docx" };
            var doc2 = new Documento { Nome = "Planilha", Tipo = "xlns" };
            var pilha = new Stack<Documento>();
            pilha.Push(doc1);
            pilha.Push(doc2);
            while (pilha.Count > 0)
            {
                Console.WriteLine($"TOTAL DE DOCUMENTOS = {pilha.Count}");
                Console.WriteLine($"DOCUMENTO {pilha.Pop().Nome}");
            }
            Console.ReadKey();
        }
    }
}
