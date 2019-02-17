using static System.Console;

namespace CursoCSharpCoder.ClassesMetodos
{
  class CarroOpcional
  {
    private string _nome;

    public string Nome
    {
      get => $"Opcional {_nome}";
      set => _nome = value;
    }

    public decimal Valor { get; set; }

    public decimal ValorComDesconto => Valor - Valor * 0.1M;
  }

  public class Propriedades
  {
    [Exercicio(numero: 29, nome: "Propriedades")]
    public static void Executa()
    {
      var op1 = new CarroOpcional();
      op1.Nome = "KA";
      op1.Valor = 20000.50M;
      // op1.ValorComDesconto = 0.5;
      WriteLine(op1.ValorComDesconto.ToString("C"));
    }
  }
}
