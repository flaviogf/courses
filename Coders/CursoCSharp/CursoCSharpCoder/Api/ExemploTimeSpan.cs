using static System.Console;
using System;

namespace CursoCSharpCoder.Api
{
  public class ExemploTimeSpan
  {
    [Exercicio(numero: 64, nome: "Exemplo Time Span")]
    public static void Executa()
    {
      var intervalo = new TimeSpan(days: 2, hours: 12, minutes: 30, seconds: 10);
      WriteLine(intervalo);
      WriteLine(intervalo.TotalMinutes);
      WriteLine(intervalo.TotalSeconds);
      WriteLine(intervalo.TotalMilliseconds);

      var agora = DateTime.Now;
      var depois = agora.Add(TimeSpan.FromMinutes(8));
      var diferenca = depois - agora;
      WriteLine(depois);
      WriteLine(diferenca);
      WriteLine(diferenca.GetType().Name);
    }
  }
}
