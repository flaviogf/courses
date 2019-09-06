using System;
using System.Threading.Tasks;
using Store.Cli.Models;

namespace Store.Cli
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            using (Context context = new Context())
            using (IProductDatabaseGateway gateway = new EntityFrameworkProductDatabaseGateway(context))
            {
                var product = new Product("Harry Potter", "Book");
                await gateway.Save(product);

            }

            using (Context context = new Context())
            using (IProductDatabaseGateway gateway = new EntityFrameworkProductDatabaseGateway(context))
            {
                var products = await gateway.All();
                foreach (var it in products)
                {
                    Console.WriteLine(it);
                }
            }
        }
    }
}
