using System;
using System.Collections.Generic;

namespace CarreiraCSharpAlura.ListLambdaLinq
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var idades = new List<int>()
			{
				1,
				2,
				3,
				4,
				5,
				6,
				7
			};

			idades.Remove(5);

			idades.AddRange(new[] {1, 2, 3});

			idades.AddAll(1, 2, 3);

			idades.Sort();

			foreach (var it in idades)
			{
				Console.WriteLine(it);
			}

			var contas = new List<ContaCorrente>
			{
				new ContaCorrente {Agencia = "123", Numero = "GHI"},
				new ContaCorrente {Agencia = "789", Numero = "ABC"},
				new ContaCorrente {Agencia = "456", Numero = "DEF"}
			};

			Console.WriteLine("Numero".PadRight(10, '*'));

			contas.Sort();

			foreach (var it in contas)
			{
				Console.WriteLine(it);
			}

			Console.WriteLine("Agencia".PadRight(10, '*'));

			contas.Sort((x, y) => y.Agencia.CompareTo(x.Agencia));

			foreach (var it in contas)
			{
				Console.WriteLine(it);
			}
		}
	}
}
