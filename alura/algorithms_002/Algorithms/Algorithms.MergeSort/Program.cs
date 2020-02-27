using System;

namespace Algorithms.MergeSort
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(new string('*', 100));

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

            foreach (var item in MergeSort(classroom1, classroom2))
            {
                Console.WriteLine(item);
            }

            var classroom = new Grade[]
            {
                new Grade("André", 4.0),
                new Grade("Mariana", 5.0),
                new Grade("Carlos", 8.5),
                new Grade("Paulo", 9.0),
                new Grade("Jonas", 3.0),
                new Grade("Juliana", 6.7),
                new Grade("Gui", 7.0),
                new Grade("Lucia", 9.3),
                new Grade("Ana", 10.0)
            };

            Console.WriteLine(new string('*', 100));

            foreach (var item in MergeSort(classroom, 0, 4, classroom.Length))
            {
                Console.WriteLine(item);
            }
        }

        public static Grade[] MergeSort(Grade[] classroom, int begin, int middle, int end)
        {
            var result = new Grade[end - begin];

            var current = 0;
            var current1 = begin;
            var current2 = middle;

            while (current1 < middle && current2 < end)
            {
                var grade1 = classroom[current1];
                var grade2 = classroom[current2];

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

            while (current1 < middle)
            {
                result[current] = classroom[current1];
                current1++;
                current++;
            }

            while (current2 < end)
            {
                result[current] = classroom[current2];
                current2++;
                current++;
            }

            for (var i = 0; i < current; i++)
            {
                classroom[begin + i] = result[i];
            }

            return classroom;
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
