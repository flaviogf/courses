using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CarreiraCSharpAlura.ArraysTiposGenericos
{
	public class ListaContaCorrente : IEnumerable<ContaCorrente>
	{
		private ContaCorrente[] _contas;

		private int _proximaPosicao;

		public ContaCorrente this[int indice] => _contas[indice];

		public int Tamanho => _contas.Length;

		public ListaContaCorrente(int tamanhoInicial = 5)
		{
			_contas = new ContaCorrente[tamanhoInicial];
		}

		public void Add(ContaCorrente conta)
		{
			if (_contas.Length <= _proximaPosicao)
			{
				var contas = new ContaCorrente[_proximaPosicao + 10];
				Array.Copy(_contas, contas, _contas.Length);
				_contas = contas;
			}

			_contas[_proximaPosicao++] = conta;
		}

		public void AddAll(params ContaCorrente[] contas)
		{
			foreach (var it in contas)
			{
				Add(it);
			}
		}

		public void Remove(ContaCorrente conta)
		{
			var index = Array.FindIndex(_contas, it => it.Equals(conta));
			_contas[index] = null;
			_contas = _contas.Where(it => it != null).ToArray();
		}

		public IEnumerator<ContaCorrente> GetEnumerator()
		{
			return _contas.Where(it => it != null).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return _contas.Where(it => it != null).GetEnumerator();
		}
	}
}
