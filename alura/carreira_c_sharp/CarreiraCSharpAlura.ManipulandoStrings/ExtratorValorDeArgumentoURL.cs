using System;
using static System.Text.RegularExpressions.Regex;
using static System.Text.RegularExpressions.RegexOptions;
using static System.String;

namespace CarreiraCSharpAlura.ManipulandoStrings
{
	public class ExtratorValorDeArgumentoUrl
	{
		/// <summary>
		/// Retorna url informada no construtor
		/// </summary>
		public string Url { get; }

		/// <summary>
		/// Extrai valores dos argumentos de uma url
		/// </summary>
		/// <param name="url"></param>
		/// <exception cref="ArgumentException"></exception>
		public ExtratorValorDeArgumentoUrl(string url)
		{
			if (IsNullOrEmpty(url))
			{
				throw new ArgumentException($"{nameof(url)} não pode ser nulo", nameof(url));
			}

			Url = url;
		}


		/// <summary>
		/// Retorna o valor da chave do argumento informado
		/// </summary>
		/// <param name="argumento"></param>
		public string PegaValor(string argumento)
		{
			return Match(Url, $@"({argumento}=)(?<Valor>\w+)", IgnoreCase).Groups["Valor"].Value;
		}
	}
}
