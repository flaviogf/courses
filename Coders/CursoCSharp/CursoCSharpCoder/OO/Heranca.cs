using static System.Console;

namespace CursoCSharpCoder.OO
{
  abstract class Carro
  {
    private readonly decimal _maxima;

    public decimal Velocidade { get; private set; }

    public Carro(decimal maxima)
    {
      WriteLine($"{GetType().Name}...");
      _maxima = maxima;
    }

    protected decimal Altera(decimal velocidade)
    {
      var delta = Velocidade + velocidade;
      if (delta < 0)
      {
        Velocidade = 0;
      }
      else if (Velocidade > _maxima)
      {
        Velocidade = _maxima;
      }
      else
      {
        Velocidade = delta;
      }
      return Velocidade;
    }

    public virtual decimal Acelera()
    {
      return Altera(5M);
    }

    public decimal Freia()
    {
      return Altera(-5M);
    }
  }

  class Uno : Carro
  {
    public Uno() : base(150M)
    {

    }
  }

  class Ferrari : Carro
  {
    public Ferrari() : base(300M)
    {

    }

    public override decimal Acelera()
    {
      return Altera(15M);
    }

    public new decimal Freia()
    {
      return Altera(-15M);
    }
  }

  public class Heranca
  {
    [Exercicio(numero: 44, nome: "Heranca")]
    public static void Executa()
    {
      var ferrari1 = new Ferrari();
      WriteLine(ferrari1.Acelera());
      WriteLine(ferrari1.Acelera());
      WriteLine(ferrari1.Freia());
      WriteLine(ferrari1.Freia());
      WriteLine(ferrari1.Freia());

      Carro ferrari2 = new Ferrari(); // chama metodo freia da classe Carro e metodo acelera da classe Ferrari
      WriteLine(ferrari2.Acelera());
      WriteLine(ferrari2.Acelera());
      WriteLine(ferrari2.Freia());
      WriteLine(ferrari2.Freia());
      WriteLine(ferrari2.Freia());
    }
  }
}
