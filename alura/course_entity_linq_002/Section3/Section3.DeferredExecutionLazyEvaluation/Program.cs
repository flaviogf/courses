using System;
using System.Linq;

namespace Section3.DeferredExecutionLazyEvaluation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(new string('*', 100));

            Lazy();

            Console.WriteLine(new string('*', 100));

            Deferred();
        }

        private static void Deferred()
        {
            var context = new Context();

            var month = 1;

            do
            {
                var employes = (from employe in context.Employes
                               where employe.Birthday.Value.Month == month
                               orderby employe.Birthday.Value.Month, employe.Birthday.Value.Day
                               select employe).ToList();

                Console.WriteLine("Month: {0}", month);

                month++;

                foreach (var item in employes)
                {
                    Console.WriteLine("{0:MM/dd}\t{1}", item.Birthday, item.Name);
                }

            } while (month <= 12);
        }

        private static void Lazy()
        {
            var context = new Context();

            var month = 1;

            do
            {
                var employes = from employe in context.Employes
                               where employe.Birthday.Value.Month == month
                               orderby employe.Birthday.Value.Month, employe.Birthday.Value.Day
                               select employe;


                Console.WriteLine("Month: {0}", month);

                month++;

                foreach (var item in employes)
                {
                    Console.WriteLine("{0:MM/dd}\t{1}", item.Birthday, item.Name);
                }

            } while (month <= 12);
        }
    }
}
