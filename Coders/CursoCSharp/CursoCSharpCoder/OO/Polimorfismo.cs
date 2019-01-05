using static System.Console;

namespace CursoCSharpCoder.OO
{
  abstract class Comida
  {
    public double Peso { get; }

    public Comida(double peso)
    {
      Peso = peso;
    }
  }

  class Feijao : Comida
  {
    public Feijao(double peso) : base(peso)
    {

    }
  }

  class Arroz : Comida
  {
    public Arroz(double peso) : base(peso)
    {

    }
  }

  class Carne : Comida
  {
    public Carne(double peso) : base(peso)
    {

    }
  }

  class Pessoa
  {
    public double Peso { get; private set; }

    public Pessoa(double peso)
    {
      Peso = peso;
    }

    public void Come(object comida)
    {
      switch (comida)
      {
        case Feijao feijao:
          Peso += feijao.Peso;
          break;
        case Arroz arroz:
          Peso += arroz.Peso;
          break;
        case Carne carne:
          Peso += carne.Peso;
          break;
      }
    }

    public void Come(Comida comida)
    {
      Peso += comida.Peso;
    }

    public override string ToString()
    {
      return $"{Peso:F2} KG";
    }
  }

  public class Polimorfismo
  {
    [Exercicio(numero: 47, nome: "Polimorfismo")]
    public static void Executa()
    {
      var cliente = new Pessoa(66);
      cliente.Come(new Arroz(0.1));
      cliente.Come(new Feijao(0.1));
      cliente.Come(new Carne(0.1));
      WriteLine(cliente);
    }
  }
}
