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
            Console.WriteLine("{0,-20} {1,-20} {2,-20}", "Id", "Amount", "Date");
        }

        [Conditional("Detailed")]
        private void Detailed()
        {
            using var context = new Context();

            var attribute = Attribute.GetCustomAttribute(typeof(Sale), typeof(DetailedReportAttribute)) as DetailedReportAttribute;

            foreach (var sale in context.Sales)
            {
                Console.WriteLine(attribute.Format, sale.Id, sale.Amount, sale.Date);
            }
        }

        [Conditional("Summarized")]
        private void Summarized()
        {
            using var context = new Context();

            var attribute = Attribute.GetCustomAttribute(typeof(Sale), typeof(SummarizedReportAttribute)) as SummarizedReportAttribute;

            foreach (var sale in context.Sales)
            {
                Console.WriteLine(attribute.Format, sale.Amount, sale.Date);
            }
        }
    }
}
