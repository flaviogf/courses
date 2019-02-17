using static System.Console;

namespace CursoCSharpCoder.Fundamentos
{
  public class VariaveisConstantes
  {
    [Exercicio(numero: 3, nome: "Variaveis e Constantes")]
    public static void Executa()
    {
      double raio = 4.5;
      const double pi = 3.14;
      WriteLine($"Area {pi * raio * raio}");

      byte menorByte = byte.MinValue;
      WriteLine("Menor Byte: {0}", menorByte);

      sbyte menorByteNegativo = sbyte.MinValue;
      WriteLine("Menor Byte Negativo: {0}", menorByteNegativo);

      int maiorInteiro = int.MaxValue;
      WriteLine("Maior inteiro: {0}", maiorInteiro);

      uint maiorInterioSemSinal = uint.MaxValue;
      WriteLine("Maior inteiro sem sinal: {0}", maiorInterioSemSinal);

      long maiorLong = long.MaxValue;
      WriteLine("Maior long: {0}", maiorLong);

      ulong maiorLongSemSinal = ulong.MaxValue;
      WriteLine("Maior long sem sinal: {0}", maiorLongSemSinal);

      float menorFloat = float.MinValue;
      WriteLine("Menor float: {0}", menorFloat);

      double menorDouble = double.MinValue;
      WriteLine("Menor double: {0}", menorDouble);

      decimal menorDecimal = decimal.MinValue;
      WriteLine("Menor decimal: {0}", menorDecimal);

      char a = 'a';
      WriteLine("Char: {0}", a);

      string texto = "TEXTO";
      WriteLine("String: {0}", texto);
    }
  }
}
