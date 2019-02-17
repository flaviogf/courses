using static System.Console;

namespace CursoCSharpCoder.Fundamentos
{
  public class Interpolacao
  {
    [Exercicio(numero: 5, nome: "Interpolacao")]
    public static void Executa()
    {
      var nome = "Notebook";
      var marca = "Dell";
      var preco = 12000;
      WriteLine("O " + nome + " da marca " + marca + " custa " + preco);
      WriteLine("O {0} da marca {1} custa {2}", nome, marca, preco);
      WriteLine($"O {nome} da marca {marca} custa {preco}");
    }
  }
}
