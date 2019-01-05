using static System.Console;
using System;

namespace CursoCSharpCoder.TopicosAvancados
{
  class Caixa<T>
  {
    private T _valor;
    public T Valor { get; set; }

    public Caixa(T valor)
    {
      _valor = valor;
    }

    public T RetornaAlgumDosValors()
    {
      return new Random().Next(0, 2) == 0 ? _valor : Valor;
    }
  }
  public class Genericos
  {
    [Exercicio(numero: 69, nome: "Genericos")]
    public static void Executa()
    {
      var caixaInteiro = new Caixa<int>(10) { Valor = 20 };
      WriteLine(caixaInteiro.RetornaAlgumDosValors());
      WriteLine(caixaInteiro.RetornaAlgumDosValors().GetType().Name);
    }
  }
}
