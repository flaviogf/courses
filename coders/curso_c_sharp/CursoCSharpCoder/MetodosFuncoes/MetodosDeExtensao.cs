using static System.Console;

namespace CursoCSharpCoder.MetodosFuncoes
{
  public static class ExtensaoInteiro
  {
    public static int Soma(this int obj, int delta)
    {
      return obj + delta;
    }
  }

  public class MetodosDeExtensao
  {
    [Exercicio(numero: 54, nome: "Metodos de Extensao")]
    public static void Executa()
    {
      WriteLine(2. Soma(2));
    }
  }
}
