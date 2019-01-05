using static System.Console;

namespace CursoCSharpCoder.ClassesMetodos
{
  public class ExemploEnum
  {
    enum Semana
    {
      Domingo,
      Segunda,
      Terca,
      Quarta,
      Quinta,
      Sexta
    }

    [Exercicio(numero: 30, nome: "Exemplo Enum")]
    public static void Executa()
    {
      WriteLine((int)Semana.Segunda);
      WriteLine(Semana.Domingo);
    }
  }
}
