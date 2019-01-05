using static System.Console;

namespace CursoCSharpCoder.ClassesMetodos
{
  class CalculadoraComum
  {
    public int Soma(int a, int b)
    {
      return a + b;
    }

    public int Subtracao(int a, int b)
    {
      return a - b;
    }

    public int Multiplicacao(int a, int b)
    {
      return a * b;
    }

    public int Divisao(int a, int b)
    {
      return a / b;
    }
  }

  class CalculadoraCadeia
  {
    public int Resultado { get; private set; }

    public CalculadoraCadeia Soma(int valor)
    {
      Resultado += valor;
      return this;
    }

    public CalculadoraCadeia Multiplica(int valor)
    {
      Resultado *= valor;
      return this;
    }

    public CalculadoraCadeia Imprime()
    {
      WriteLine("Resultado: {0}", Resultado);
      return this;
    }

    public CalculadoraCadeia Limpa()
    {
      Resultado = 0;
      return this;
    }
  }

  public class MetodosComRetorno
  {
    [Exercicio(numero: 24, nome: "Metodos Com Retorno")]
    public static void Executa()
    {
      var calc = new CalculadoraComum();
      WriteLine("Soma: {0}", calc.Soma(2, 2));
      WriteLine("Subtracao: {0}", calc.Subtracao(2, 2));
      WriteLine("Multiplicacao: {0}", calc.Multiplicacao(2, 2));
      WriteLine("Divisao: {0}", calc.Divisao(2, 2));
      var resultado = new CalculadoraCadeia().Soma(3).Multiplica(3).Imprime().Limpa().Imprime().Soma(3).Soma(3).Resultado;
      WriteLine("Resultado Final: {0:C}", resultado);
    }
  }
}
