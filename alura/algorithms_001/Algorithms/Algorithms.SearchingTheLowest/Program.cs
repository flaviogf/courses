using System;

namespace Algorithms.SearchingTheLowest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var products = new Product[]
            {
                new Product("Lamborghini", 1_000_000_000),
                new Product("Jipe", 46_000),
                new Product("Brasilia", 16_000),
                new Product("Smart", 46_000),
                new Product("Fusca", 17_000)
            };

            var lowest = SearchLowest(products, 0, products.Length);

            Console.WriteLine($"The lowest product is {products[lowest].Name} {products[lowest].Price:C}");
        }

        public static int SearchLowest(Product[] products, int begin, int end)
        {
            var lowest = begin;

            for (var current = begin; current < end; current++)
            {
                if (products[current].Price < products[lowest].Price)
                {
                    lowest = current;
                }
            }

            return lowest;
        }
    }
}
