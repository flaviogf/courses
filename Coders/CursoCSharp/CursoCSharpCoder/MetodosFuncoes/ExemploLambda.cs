using static System.Console;
using System;

namespace CursoCSharpCoder.MetodosFuncoes
{
  public class ExemploLambda
  {
    [Exercicio(numero: 50, nome: "Exemplo Lambda")]
    public static void Executa()
    {
      Func<int, int, int, string> formataData = (dia, mes, ano) => $"{dia:D2}/{mes:D2}/{ano:D2}";
      Func<int, string> conversorHex = numero => numero.ToString("X");
      Func<int> aleatorio = () => new Random().Next(1, 10);
      Action imprime = () => WriteLine("Lambda C#");
      WriteLine(formataData(12, 10, 2018));
      WriteLine(conversorHex(10));
      WriteLine(aleatorio());
      imprime();
    }
  }
}
