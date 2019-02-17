using System;
using static System.Console;

namespace CursoCSharpCoder.ClassesMetodos
{
  class Cliente
  {
    public readonly string _nome;

    private readonly DateTime _nascimento;

    public Cliente(string nome, DateTime nascimento)
    {
      _nome = nome;
      _nascimento = nascimento;
    }

    public override string ToString()
    {
      return $"Nome: {_nome}, Nascimento: {_nascimento:dd/MM/yyyy}";
    }
  }

  public class Readonly
  {
    [Exercicio(numero: 29, nome: "Readonly")]
    public static void Executa()
    {
      var cliente = new Cliente("Teste", DateTime.Now);
      WriteLine(cliente);
    }
  }
}
