using static System.Console;

namespace CursoCSharpCoder.ClassesMetodos
{
  public class ValorVsReferencia
  {
    // class Dependente
    struct Dependente
    {
      public string Nome;
      public int Idade;
    }

    [Exercicio(numero: 33, nome: "Valor Vs Referencia")]
    public static void Executa()
    {
      var dep = new Dependente { Nome = "Teste", Idade = 100 };
      var depCopia = dep;
      WriteLine($"Dep {dep.Nome} Copia {depCopia.Nome}");
      WriteLine($"Dep {dep.Idade} Copia {depCopia.Idade}");
      WriteLine();
      dep.Nome = "Jõao";
      dep.Idade = 40;
      WriteLine($"Dep {dep.Nome} Copia {depCopia.Nome}");
      WriteLine($"Dep {dep.Idade} Copia {depCopia.Idade}");
    }
  }
}
