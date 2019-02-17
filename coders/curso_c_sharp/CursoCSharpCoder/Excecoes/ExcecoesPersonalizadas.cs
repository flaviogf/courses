using static System.Console;
using System;

namespace CursoCSharpCoder.Excecoes
{
  class NegativoException : Exception
  {
    public NegativoException() { }

    public NegativoException(string mensagem) : base(mensagem) { }
  }

  class ImparException : Exception
  {
    public ImparException() { }

    public ImparException(string mensagem) : base(mensagem) { }
  }

  public class ExcecoesPersonalizadas
  {
    public static int ParPositivo()
    {
      var valor = new Random().Next(-30, 30);

      if (valor < 0)
      {
        throw new NegativoException("Numero negativo :(");
      }

      if (valor % 2 != 0)
      {
        throw new ImparException("Numero impar :(");
      }

      return valor;
    }

    [Exercicio(numero: 56, nome: "Excecoes Personalizadas")]
    public static void Executa()
    {
      try
      {
        WriteLine(ParPositivo());
      }
      catch (NegativoException ex)
      {
        WriteLine(ex.Message);
      }
      catch (ImparException ex)
      {
        WriteLine(ex.Message);
      }
    }
  }
}
