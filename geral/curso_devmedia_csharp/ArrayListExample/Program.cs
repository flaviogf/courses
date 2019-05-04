using System;
using System.Collections;

namespace ArrayListExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = new ArrayList();
            array.Add("Flavio");
            array.Add("Fernandes");
            array.Add(20);
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(array.Capacity);
            Console.WriteLine(array.Count);
            Console.ReadKey();
        }
    }
}
