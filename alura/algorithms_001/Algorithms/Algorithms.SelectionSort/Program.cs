using System;

namespace Algorithms.SelectionSort
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

            for (var current = 0; current < products.Length; current++)
            {
                var lowest = SearchLowest(products, current, products.Length);

                var currentProduct = products[current];
                var lowestProduct = products[lowest];

                products[current] = lowestProduct;
                products[lowest] = currentProduct;
            }

            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
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
