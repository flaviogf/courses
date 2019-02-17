using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace CursoCSharpCoder.OO
{
  interface OperacaoBinaria
  {
    double Operacao(double x, double y);
  }

  class Soma : OperacaoBinaria
  {
    public double Operacao(double x, double y)
    {
      return x + y;
    }
  }

  class Multiplicacao : OperacaoBinaria
  {
    public double Operacao(double x, double y)
    {
      return x * y;
    }
  }

  class Calculadora
  {
    private List<OperacaoBinaria> operacoes = new List<OperacaoBinaria>
    {
      new Soma(),
      new Multiplicacao()
    };

    public double Calcula(int x, int y)
    {
      return operacoes.Sum(it => it.Operacao(x, y));
    }
  }

  public class ExemploInterface
  {
    [Exercicio(numero: 48, nome: "Interfaces")]
    public static void Executa()
    {
      var calculadora = new Calculadora();
      WriteLine(calculadora.Calcula(10, 10));
    }
  }
}
