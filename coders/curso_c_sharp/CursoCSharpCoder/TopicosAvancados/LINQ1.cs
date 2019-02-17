using static System.Console;
using System.Collections.Generic;
using System.Linq;

namespace CursoCSharpCoder.TopicosAvancados
{
  class Aluno
  {
    public string Nome { get; set; }
    public int Idade { get; set; }
    public double Nota { get; set; }

    public override string ToString()
    {
      return $"Nome={Nome}, Idade={Idade}, Nota={Nota:F2}";
    }
  }
  public class LINQ1
  {
    [Exercicio(numero: 65, nome: "LINQ1")]
    public static void Executa()
    {
      var alunos = new List<Aluno>
      {
        new Aluno { Nome = "Flavio", Idade = 22, Nota = 8.5 },
        new Aluno { Nome = "Fernando", Idade = 24, Nota = 6.5 },
        new Aluno { Nome = "Luis Fernando", Idade = 47, Nota = 9.5 }
      };

      WriteLine("Aprovados ".PadRight(100, '='));

      var aprovados = from aluno in alunos where aluno.Nota >= 7 orderby aluno.Nota descending select aluno;

      foreach (var aprovado in aprovados)
      {
        WriteLine(aprovado);
      }

      WriteLine("Chamada ".PadRight(100, '='));

      var chamada = from aluno in alunos orderby aluno.Nome select aluno.Nome;

      foreach (var aluno in chamada)
      {
        WriteLine(aluno);
      }

      WriteLine("Media ".PadRight(100, '='));

      WriteLine(alunos.Where(it => it.Nota >= 7).Select(it => it.Nota).Average());
    }
  }
}
