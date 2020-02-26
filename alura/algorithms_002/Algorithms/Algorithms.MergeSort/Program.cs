using System;

namespace Algorithms.MergeSort
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var classroom1 = new Grade[]
            {
                new Grade("André", 4.0),
                new Grade("Mariana", 5.0),
                new Grade("Carlos", 8.5),
                new Grade("Paulo", 9.0),
            };

            var classroom2 = new Grade[]
            {
                new Grade("Jonas", 3.0),
                new Grade("Juliana", 6.7),
                new Grade("Gui", 7.0),
                new Grade("Lucia", 9.3),
                new Grade("Ana", 10.0),
            };

            var grades = MergeSort(classroom1, classroom2);

            foreach (var item in grades)
            {
                Console.WriteLine(item);
            }
        }

        public static Grade[] MergeSort(Grade[] grades1, Grade[] grades2)
        {
            var result = new Grade[grades1.Length + grades2.Length];

            var current = 0;
            var current1 = 0;
            var current2 = 0;

            while (current1 < grades1.Length && current2 < grades2.Length)
            {
                var grade1 = grades1[current1];
                var grade2 = grades2[current2];

                if (grade1.Value < grade2.Value)
                {
                    result[current] = grade1;
                    current1++;
                }
                else
                {
                    result[current] = grade2;
                    current2++;
                }

                current++;
            }

            while (current1 < grades1.Length)
            {
                result[current] = grades1[current1];
                current1++;
                current++;
            }

            while (current2 < grades2.Length)
            {
                result[current] = grades2[current2];
                current2++;
                current++;
            }

            return result;
        }
    }
}
