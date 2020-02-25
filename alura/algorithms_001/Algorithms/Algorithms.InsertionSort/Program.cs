using System;

namespace Algorithms.InsertionSort
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var products = new Product[]
            {
                new Product("Lamborghini", 1_000_000),
                new Product("Jipe", 46_000),
                new Product("Brasilia", 16_000),
                new Product("Smart", 46_000),
                new Product("Fusca", 17_000)
            };

            InsertionSort(products, products.Length);

            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
        }

        public static void InsertionSort(Product[] products, int quantity)
        {
            for (var current = 1; current < quantity; current++)
            {
                var analysis = current;

                while (analysis > 0 && products[analysis].Price < products[analysis - 1].Price)
                {
                    var productBeforeTheProductInAnalysis = products[analysis - 1];
                    var productInAnalysis = products[analysis];
                    products[analysis - 1] = productInAnalysis;
                    products[analysis] = productBeforeTheProductInAnalysis;
                    analysis--;
                }
            }
        }
    }
}
