using System.Linq;
using static System.Console;

namespace CarreiraCSharpAlura.ArraysTiposGenericos
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var idades = new int[5];

			idades[0] = 20;
			idades[1] = 21;
			idades[2] = 22;
			idades[3] = 23;
			idades[4] = 24;

			WriteLine($"Array indice 4 = {idades[4]}");

			WriteLine($"Tamanho array = {idades.Length}");

			foreach (var (item, index) in idades.Select((item, index) => (item, index)))
			{
				WriteLine($"Acessando idade[{index}] = {item}");
			}

			var notas = new[] {1.0, 2.0, 8.0, 10.0};

			WriteLine($"Média = {notas.Average()}");


			var contaTeste = new ContaCorrente("0000", "0000");

			var contas = new ListaContaCorrente
			{
				new ContaCorrente("1111", "1111"),
				new ContaCorrente("2222", "2222"),
				new ContaCorrente("3333", "3333"),
				contaTeste
			};

			WriteLine($"Tamanho lista contas {contas.Tamanho}");

			contas.Add(new ContaCorrente("4444", "4444"));
			contas.Add(new ContaCorrente("5555", "5555"));
			contas.Add(new ContaCorrente("6666", "6666"));
			contas.Add(new ContaCorrente("7777", "7777"));

			contas.AddAll(new ContaCorrente("8888", "8888"), new ContaCorrente("9999", "9999"));

			WriteLine($"Tamanho lista contas {contas.Tamanho}");

			WriteLine(contas[0]);

			WriteLine("Antes".PadRight(100, '*'));

			foreach (var conta in contas)
			{
				WriteLine(conta);
			}

			contas.Remove(contaTeste);

			WriteLine("Depois".PadRight(100, '*'));

			foreach (var conta in contas)
			{
				WriteLine(conta);
			}

			var nomes = new Lista<string>()
			{
				"Teste 1",
				"Teste 2"
			};

			nomes.AddAll("Teste 3", "Teste 4");

			nomes.Remove("Teste 3");

			WriteLine("Nomes".PadRight(100, '*'));

			foreach (var it in nomes)
			{
				WriteLine(it);
			}
		}
	}
}
