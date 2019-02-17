using static System.Console;
using CarreiraCSharpAlura.ByteBank.Funcionarios;

namespace CarreiraCSharpAlura.ByteBank
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var gerenciador = new GerenciadorBonificacao();

            var flavio = new Diretor("123.123.123.12", 5000M);
            flavio.Nome = "Flávio";

            var fernando = new Designer("123.123.123.17", 1000M);
            fernando.Nome = "Fernando";

            gerenciador.Registra(fernando);
            gerenciador.Registra(flavio);
            WriteLine(gerenciador.TotalBonificacao.ToString("C"));
        }
    }
}
