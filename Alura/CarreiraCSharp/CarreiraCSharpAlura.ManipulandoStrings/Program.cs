using static System.Console;
using static System.Text.RegularExpressions.Regex;

namespace CarreiraCSharpAlura.ManipulandoStrings
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var extrator = new ExtratorValorDeArgumentoUrl("pagina?argumento1=Teste&moeda=Real");
			WriteLine(extrator.Url);
			var arg1 = extrator.PegaValor("argumento1");
			WriteLine(arg1);
			WriteLine(extrator.PegaValor("moeda"));
			WriteLine(extrator.PegaValor("MOEDA"));
			WriteLine(extrator.PegaValor("ARGUMENTO1"));
			WriteLine(arg1.ToLower());
			WriteLine(arg1.ToUpper());
			WriteLine(arg1.Contains("est"));
			WriteLine(arg1.StartsWith("Tes"));
			WriteLine(arg1.EndsWith("e"));
			var padrao1 =
				@"[0123456789][0123456789][0123456789][0123456789][-]?[0123456789][0123456789][0123456789][0123456789]";
			var padrao2 =
				@"[0-9]{4,5}-?[0-9]{4}";
			var texto1 = "Meu número de telefone é 7894-4654";
			WriteLine(Match(texto1, padrao1));
			WriteLine(IsMatch(texto1, padrao1));
			WriteLine(Match(texto1, padrao2));
			WriteLine(IsMatch(texto1, padrao2));
			var texto2 = "Meu número de telefone é 78944654";
			WriteLine(Match(texto2, padrao1));
			WriteLine(IsMatch(texto2, padrao1));
			WriteLine(Match(texto2, padrao2));
			WriteLine(IsMatch(texto2, padrao2));
			ReadKey();
		}
	}
}
