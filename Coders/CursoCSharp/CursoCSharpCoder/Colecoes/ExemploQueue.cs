using System.Collections.Generic;
using static System.Console;

namespace CursoCSharpCoder.Colecoes
{
  public class ExemploQueue
  {
    [Exercicio(numero: 40, nome: "Queue")]
    public static void Executa()
    {
      var fila = new Queue<string>
      {
        "Teste 1",
        "Teste 2",
        "Teste 3"
      };
      fila.Enqueue("Teste 4");
      fila.Enqueue("Teste 5");
      WriteLine(fila.Peek());
      WriteLine(fila.Count);
      WriteLine(fila.Dequeue());
      WriteLine(fila.Count);
      foreach (var item in fila)
      {
        WriteLine(item);
      }

    }
  }

  static class ExtensaoQueue
  {
    public static void Add<T>(this Queue<T> obj, T item)
    {
      obj.Enqueue(item);
    }
  }
}
