using static System.Console;

namespace CursoCSharpCoder.Fundamentos
{
  public class NotacaoPonto
  {
    [Exercicio(numero: 6, nome: "Notacao Ponto")]
    public static void Executa()
    {
      var saudacao = "ola".ToUpper().Insert(3, " WORLD!").Replace("WORLD!", "MUNDO");
      WriteLine(saudacao);
      string nome = null;
      WriteLine(nome?.Length);
    }
  }
}
