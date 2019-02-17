using System;

namespace CarreiraCSharpAlura.ListLambdaLinq
{
	/// <summary>
	/// Define uma Conta Corrente
	/// </summary>
	public class ContaCorrente : IComparable<ContaCorrente>
	{
		public string Agencia { get; set; }

		public string Numero { get; set; }

		public int CompareTo(ContaCorrente other)
		{
			return other.Numero.CompareTo(Numero);
		}

		public override string ToString()
		{
			return $"{Agencia}/{Numero}";
		}
	}
}
