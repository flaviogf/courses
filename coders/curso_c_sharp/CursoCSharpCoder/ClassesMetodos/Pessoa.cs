namespace CursoCSharpCoder.ClassesMetodos
{
  public class Pessoa
  {
    public string Nome;
    public int Idade;

    public string Apresenta()
    {
      return $"Meu nome é {Nome} e tenho {Idade} anos";
    }
  }
}
