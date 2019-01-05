namespace CursoEntityFrameworkCore.ConsoleApp
{
    public class Endereco
    {
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public Cliente Cliente { get; set; }
    }
}
