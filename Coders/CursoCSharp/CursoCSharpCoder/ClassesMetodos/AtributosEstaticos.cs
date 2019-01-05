using static System.Console;

namespace CursoCSharpCoder.ClassesMetodos
{
  class Produto
  {
    public string Nome { get; set; }

    public decimal Valor { get; set; }

    public static decimal Desconto;

    public decimal ValorFinal => Valor - Valor * Desconto;

    public Produto(string nome, decimal valor, decimal desconto)
    {
      Nome = nome;
      Valor = valor;
      Desconto = desconto;
    }
  }

  public class AtributosEstaticos
  {
    [Exercicio(numero: 26, nome: "Atributos Estaticos")]
    public static void Executa()
    {
      var p1 = new Produto("Caneta", 2.5M, 0.5M);
      var p2 = new Produto("Carro", 20000M, 0.25M);
      WriteLine("P1(ValorComDesconto={0:C})", p1.ValorFinal);
      WriteLine("P2(ValorComDesconto={0:C})", p2.ValorFinal);
      Produto.Desconto = 1;
      WriteLine("P1(ValorComDesconto={0:C})", p1.ValorFinal);
      WriteLine("P2(ValorComDesconto={0:C})", p2.ValorFinal);
    }
  }
}
