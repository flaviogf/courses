using static System.Console;

namespace CursoCSharpCoder.ClassesMetodos
{
  public class ParametrosNomeados
  {
    public static string Formata(int dia, int mes, int ano)
    {
      return $"{dia:D2}/{mes:D2}/{ano}";
    }

    [Exercicio(numero: 28, nome: "Parametros Nomeados")]
    public static void Executa()
    {
      WriteLine(Formata(mes: 12, dia: 10, ano: 2018));
      WriteLine(Formata(ano: 2018, mes: 12, dia: 30));
      WriteLine(Formata(ano: 2018, mes: 1, dia: 8));
    }
  }
}
