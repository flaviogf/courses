using static System.Console;
using System;

namespace CursoCSharpCoder.MetodosFuncoes
{
  delegate string InverteDelegate(string texto);

  public class FuncaoAnonima
  {
    [Exercicio(numero: 52, nome: "Funcao Anonima")]
    public static void Executa()
    {
      InverteDelegate inverte = delegate(string texto)
      {
        var array = texto.ToCharArray();
        Array.Reverse(array);
        return new string(array);
      };
      WriteLine(inverte("C# é show!!"));
    }
  }
}
