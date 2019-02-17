using System.Collections.Generic;
using static System.Console;

namespace CursoCSharpCoder.OO
{
  abstract class Celular
  {
    public virtual string Toque => "Trim, trim, trim...";
    public abstract string SO { get; }

    public override string ToString()
    {
      return $"SO: {SO} - Toque: {Toque}";
    }
  }

  class Samsung : Celular
  {
    public override string SO => "Android";
  }

  class Iphone : Celular
  {
    public override string SO => "IOs";
  }

  public class ClasseAbstrata
  {
    [Exercicio(numero: 48, nome: "Classe Abstrata")]
    public static void Executa()
    {
      var celulares = new List<Celular>
      {
        new Samsung(),
        new Iphone()
      };
      celulares.ForEach(WriteLine);
    }
  }
}
