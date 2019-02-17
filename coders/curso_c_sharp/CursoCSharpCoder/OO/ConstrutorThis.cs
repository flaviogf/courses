using static System.Console;

namespace CursoCSharpCoder.OO
{
  class Animal
  {
    public string Nome { get; set; }

    public Animal(string nome)
    {
      Nome = nome;
    }
  }

  class Cachorro : Animal
  {
    public double Altura { get; set; }

    public Cachorro(string nome) : base(nome)
    {

    }

    public Cachorro(string nome, double altura) : this(nome)
    {
      Altura = altura;
    }

    public override string ToString()
    {
      return $"{Nome} tem {Altura:F2} cm de altura";
    }
  }

  public class ConstrutorThis
  {
    [Exercicio(numero: 45, nome: "Construtor This")]
    public static void Executa()
    {
      var tank = new Cachorro("Tank");
      var frank = new Cachorro("Frank", 0.8);
      WriteLine(tank);
      WriteLine(frank);
    }
  }
}
