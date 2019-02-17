using static System.Console;

namespace CursoCSharpCoder.ClassesMetodos
{
  struct SPonto
  {
    public int X;
    public int Y;
  }

  class CPonto
  {
    public int X;
    public int Y;
  }

  public class StructVsClasse
  {
    [Exercicio(numero: 32, nome: "Struct Vs Classe")]
    public static void Executa()
    {
      // atribuicao por valor
      var sponto = new SPonto { X = 1, Y = 1 };
      var copiaSponto = sponto;
      sponto.X = 10;
      WriteLine("SPONTO X {0}", sponto.X);
      WriteLine("COPIA SPONTO X {0}", copiaSponto.X);

      // atribuicao por referencia
      var cponto = new CPonto { X = 1, Y = 1 };
      var copiaCponto = cponto;
      cponto.X = 20;
      WriteLine("CPONTO X {0}", cponto.X);
      WriteLine("COPIA CPONTO X {0}", copiaCponto.X);
    }
  }
}
