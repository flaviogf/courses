using static System.Console;

namespace CursoCSharpCoder.Fundamentos
{
  public class Conversoes
  {
    [Exercicio(numero: 9, nome: "Conversoes")]
    public static void Executa()
    {
      int inteiro = 10;
      double quebrado = inteiro;
      WriteLine(quebrado);

      double nota = 9.7;
      int notaInteira = (int)nota;
      WriteLine(notaInteira);

      Write("Digite sua idade: ");
      string idadeString = ReadLine();
      int idade = int.Parse(idadeString);
      WriteLine("Idade: {0}", idade);
    }
  }
}
