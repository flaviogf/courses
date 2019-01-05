using System.Collections.Generic;

namespace CarreiraCSharpAlura.ListLambdaLinq
{
	//public static class ListExtensions
	//{
	//	public static void AddAll(this List<int> lista, params int[] itens)
	//	{
	//		lista.AddRange(itens);
	//	}
	//}

	public static class ListExtensions
	{
		public static void AddAll<T>(this List<T> lista, params T[] itens)
		{
			lista.AddRange(itens);
		}
	}
}
