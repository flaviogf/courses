using static System.Console;

namespace CursoCSharpCoder.ClassesMetodos
{
  public class Membros
  {
    [Exercicio(numero: 22, nome: "Membros")]
    public static void Executa()
    {
      var pessoa = new Pessoa();
      pessoa.Nome = "João";
      pessoa.Idade = 60;
      WriteLine(pessoa.Apresenta());
    }
  }
}
