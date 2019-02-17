using static System.Console;

namespace CursoCSharpCoder.Fundamentos
{
  public class LendoDados
  {
    [Exercicio(numero: 7, nome: "Lendo Dados")]
    public static void Executa()
    {
      Write("Nome: ");
      var nome = ReadLine();
      Write("Idade: ");
      int.TryParse(ReadLine(), out var idade);
      WriteLine($"Nome: {nome} - Idade: {idade}");
    }
  }
}
