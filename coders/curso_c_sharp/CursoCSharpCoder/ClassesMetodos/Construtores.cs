using static System.Console;

namespace CursoCSharpCoder.ClassesMetodos
{
  class Carro
  {
    public string Modelo;
    public string Marca;
    public int Ano;

    public Carro()
    {

    }

    public Carro(string modelo, string marca, int ano)
    {
      Modelo = modelo;
      Marca = marca;
      Ano = ano;
    }
  }

  public class Construtores
  {
    [Exercicio(numero: 23, nome: "Construtores")]
    public static void Executa()
    {
      var c1 = new Carro();
      c1.Modelo = "KA";
      c1.Marca = "FORD";
      c1.Ano = 2018;
      WriteLine($"c1(Modelo={c1.Modelo},Marca={c1.Marca},Ano={c1.Ano})");
      var c2 = new Carro("CLASSIC", "CHEVROLET", 2012);
      WriteLine($"c2(Modelo={c2.Modelo},Marca={c2.Marca},Ano={c2.Ano})");
    }
  }
}
