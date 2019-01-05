using static System.Console;

namespace CursoCSharpCoder.Encapsulamento
{
  public class Acesso
  {
    public string Publico => "Publico";

    protected string Protegido => "Protegido";

    internal string Interno => "Interno";

    protected internal string ProtegidoInterno => "Protegido Interno";

    // private protected string PrivadoProtegido => "Privado Protegido"; C# > 7.2

    public Acesso()
    {
      WriteLine(GetType().Name);
    }

    public virtual void MeusAcessos()
    {
      WriteLine(Publico);
      WriteLine(Protegido);
      WriteLine(Interno);
      WriteLine(ProtegidoInterno);
      WriteLine("Privado Protegido C# > 7.2");
    }
  }
}
