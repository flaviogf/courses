using System;
using System.Collections;

namespace HashTableExample
{
    class Aluno
    {
        public string Nome { get; set; }
        public int Matricula { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var turma = new Hashtable()
            {
                [1] = "Flavio",
                [2] = "Fernando"
            };
            Console.WriteLine($"Aluno numero 1 {turma[1]}");
            Console.WriteLine("Alunos turma 1");
            foreach (var aluno in turma.Values)
            {
                Console.WriteLine(aluno);
            }
            Console.WriteLine($"Contém a matricula 2? {turma.ContainsKey(2)}");
            var turma2 = new Hashtable
            {
                [1] = new Aluno { Matricula = 1, Nome = "Flávio" },
                [2] = new Aluno { Matricula = 2, Nome = "Fernando" }
            };
            var alunoTurma2 = turma2[1] as Aluno;
            Console.WriteLine($"Matricula {alunoTurma2.Matricula} - Nome {alunoTurma2.Nome}");
            Console.ReadKey();
        }
    }
}
