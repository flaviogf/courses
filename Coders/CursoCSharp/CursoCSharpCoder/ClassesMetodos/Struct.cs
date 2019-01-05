using static System.Console;

namespace CursoCSharpCoder.ClassesMetodos
{
  public class ExemploStruct
  {
    interface Ponto
    {
      void Move(int delta);
    }

    struct Coordenada : Ponto
    {
      public int X;
      public int Y;

      public Coordenada(int x, int y)
      {
        X = x;
        Y = y;
      }

      public void Move(int delta)
      {
        X += delta;
        Y += delta;
      }

      public override string ToString()
      {
        return $"X{X} - Y{Y}";
      }
    }

    [Exercicio(numero: 31, nome: "Exemplo Struct")]
    public static void Executa()
    {
      Coordenada coord;
      coord.X = 1;
      coord.Y = 2;
      coord.Move(20);
      WriteLine(coord);
    }
  }
}
