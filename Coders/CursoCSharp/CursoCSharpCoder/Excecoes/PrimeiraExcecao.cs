using static System.Console;
using System;

namespace CursoCSharpCoder.Excecoes
{
  class Conta
  {
    public decimal Saldo { get; private set; }

    public Conta(decimal saldo)
    {
      Saldo = saldo;
    }

    public decimal Saca(decimal valor)
    {
      return Saldo - valor >= 0 ? Saldo -= valor : throw new ArgumentException("Saldo indisponivel");
    }
  }
  public class PrimeiraExcecao
  {
    [Exercicio(numero: 55, nome: "Primeira Excecao")]
    public static void Executa()
    {
      try
      {
        var conta = new Conta(200);
        WriteLine(conta.Saca(100));
        WriteLine(conta.Saca(200));
      }
      catch (ArgumentException ex)
      {
        WriteLine(ex.Message);
      }
    }
  }
}
