using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CarreiraCSharpAlura.ArraysTiposGenericos
{
	public class Lista<T> : IEnumerable<T> where T : class
	{
		private T[] _contas;

		private int _proximaPosicao;

		public T this[int indice] => _contas[indice];

		public int Tamanho => _contas.Length;

		public Lista(int tamanhoInicial = 5)
		{
			_contas = new T[tamanhoInicial];
		}

		public void Add(T conta)
		{
			if (_contas.Length <= _proximaPosicao)
			{
				var contas = new T[_proximaPosicao + 10];
				Array.Copy(_contas, contas, _contas.Length);
				_contas = contas;
			}

			_contas[_proximaPosicao++] = conta;
		}

		public void AddAll(params T[] contas)
		{
			foreach (var it in contas)
			{
				Add(it);
			}
		}

		public void Remove(T conta)
		{
			var index = Array.FindIndex(_contas, it => it.Equals(conta));
			_contas[index] = null;
			_contas = _contas.Where(it => it != null).ToArray();
		}

		public IEnumerator<T> GetEnumerator()
		{
			return _contas.Where(it => it != null).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return _contas.Where(it => it != null).GetEnumerator();
		}
	}
}
