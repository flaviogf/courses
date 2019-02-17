using static System.Console;
using System;

namespace CursoCSharpCoder.Api
{
  public class ExemploDateTime
  {
    [Exercicio(numero: 63, nome: "Exemplo DateTime")]
    public static void Executa()
    {
      var nascimento = new DateTime(year: 1997, month: 6, day: 13);
      WriteLine($"{nascimento:G}");
      WriteLine($"{nascimento:g}");
      WriteLine($"{nascimento:d}");
      WriteLine($"{nascimento:dd}");
      WriteLine($"{nascimento:D}");

      var hoje = DateTime.Today;
      WriteLine(hoje);

      var agora = DateTime.Now;
      WriteLine(hoje);
    }
  }
}
