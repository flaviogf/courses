using static System.Console;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CursoCSharpCoder.TopicosAvancados
{
  public class LINQ2
  {
    [Exercicio(numero: 66, nome: "LINQ2")]
    public static void Executa()
    {
      var alunos = new List<Aluno>
      {
        new Aluno { Nome = "Flavio", Idade = 22, Nota = 8.5 },
        new Aluno { Nome = "Fernando", Idade = 24, Nota = 6.5 },
        new Aluno { Nome = "Luis Fernando", Idade = 47, Nota = 9.5 }
      };

      var aluno1 = alunos.FirstOrDefault(it => it.Nome.Equals("teste", StringComparison.InvariantCultureIgnoreCase));
      var aluno2 = alunos.First(it => it.Nome.Equals("fernando", StringComparison.InvariantCultureIgnoreCase));
      WriteLine(aluno1?.Nome);
      WriteLine(aluno2.Nome);

      WriteLine($"Media Aprovados {alunos.Where(it => it.Nota >= 7).Select(it => it.Nota).Average():F2}");
      WriteLine($"Maior Nota {alunos.Max(it => it.Nota):F2}");
      WriteLine($"Menor Nota {alunos.Select(it=>it.Nota).Min():F2}");
    }
  }
}
