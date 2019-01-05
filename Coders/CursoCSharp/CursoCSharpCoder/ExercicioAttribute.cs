using System;

namespace CursoCSharpCoder
{
  [AttributeUsage(AttributeTargets.Method)]
  public class ExercicioAttribute : Attribute
  {
    public string Nome { get; }

    public int Numero { get; }

    public ExercicioAttribute(string nome, int numero)
    {
      Nome = nome;
      Numero = numero;
    }

    public override string ToString()
    {
      return $"{Numero:D3} - {Nome}";
    }
  }
}
