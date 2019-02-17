using System.Collections.Generic;
using static System.Console;

namespace CursoCSharpCoder.Colecoes
{
  public class ExemploStack
  {
    [Exercicio(numero: 42, nome: "Stack")]
    public static void Executa()
    {
      var pilha = new Stack<Produto>();
      pilha.Push(new Produto { Nome = "Teste 1", Preco = 100M });
      pilha.Push(new Produto { Nome = "Teste 2", Preco = 200M });
      foreach (var produto in pilha)
      {
        WriteLine(produto);
      }
      WriteLine(pilha.Peek());
      WriteLine(pilha.Count);
      WriteLine(pilha.Pop());
      WriteLine(pilha.Count);
    }
  }
}
