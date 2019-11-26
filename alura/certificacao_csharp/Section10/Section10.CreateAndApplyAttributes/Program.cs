using System;
using System.Threading.Tasks;

namespace Section10.CreateAndApplyAttributes
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            IReport report = new ConsoleReport();

            await report.Print();

            Console.WriteLine("Is Sale serializable? {0}", Attribute.IsDefined(typeof(Sale), typeof(SerializableAttribute)));
        }
    }
}
