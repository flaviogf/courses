using System.Collections;
using static System.Console;

namespace CursoCSharpCoder.Colecoes
{
  public class ExemploArrayList
  {
    [Exercicio(numero: 38, nome: "Array List")]
    public static void Executa()
    {
      var itens = new ArrayList();
      itens.Add("teste");
      itens.Add('a');
      itens.Add(1);
      foreach (var item in itens)
      {
        WriteLine("Tipo {0} - Valor {1}", item.GetType(), item);
      }
    }
  }
}
