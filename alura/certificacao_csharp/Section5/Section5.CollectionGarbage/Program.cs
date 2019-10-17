using System;

namespace Section5.CollectionGarbage
{
    public class Program
    {
        public static void Main(string[] args)
        {
            for (int i = 0; i < 1000000; i++)
            {
                new Person
                {
                    Name = "Test"
                };
            }

            // GC.Collect();
        }
    }

    public class Person
    {
        public string Name { get; set; }

        public Person()
        {
            Console.WriteLine("Begin");
        }

        ~Person()
        {
            Console.WriteLine("End");
        }
    }
}
