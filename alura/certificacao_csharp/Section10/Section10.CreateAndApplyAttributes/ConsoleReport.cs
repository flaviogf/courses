#define Detailed

using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Section10.CreateAndApplyAttributes
{
    public class ConsoleReport : IReport
    {
        public Task Print()
        {
            Header();

            Detailed();

            Summarized();

            return Task.CompletedTask;
        }

        [Conditional("Detailed"), Conditional("Summarized")]
        private void Header()
        {
            Console.WriteLine("Header");
        }

        [Conditional("Detailed")]
        private void Detailed()
        {
            using var context = new Context();

            foreach (var sale in context.Sales)
            {
                Console.WriteLine(sale);
            }
        }

        [Conditional("Summarized")]
        private void Summarized()
        {
            using var context = new Context();

            foreach (var sale in context.Sales)
            {
                Console.WriteLine(sale);
            }
        }
    }
}
