using System;

namespace CarreiraCSharpAlura.ArraysTiposGenericos
{
	public class ContaCorrente
	{
		public string Numero { get; set; }

		public string Agencia { get; set; }

		public ContaCorrente(string numero, string agencia)
		{
			Numero = numero;
			Agencia = agencia;
		}

		public override string ToString() => $"Conta(Numero={Numero}, Agencia={Agencia})";

		public override bool Equals(object obj)
		{
			if (obj is ContaCorrente conta)
			{
				return conta.Numero.Equals(Numero, StringComparison.CurrentCultureIgnoreCase);
			}

			return false;
		}
	}
}
