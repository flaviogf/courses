using System;

namespace Algorithms.MergeSort
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //StepOne();

            //StepTwo();

            //StepThree();

            static void sort(int[] cards, int begin, int end)
            {
                var length = end - begin;

                if (length > 1)
                {
                    var middle = (begin + end) / 2;
                    sort(cards, begin, middle);
                    sort(cards, middle + 1, end);
                    merge(cards, begin, middle, end);
                }
            }

            static void merge(int[] items, int begin, int middle, int end)
            {
                var current = 0;
                var current1 = begin;
                var current2 = middle;

                var result = new int[end - begin];

                while (current1 < middle && current2 < end)
                {
                    var item1 = items[current1];
                    var item2 = items[current2];

                    if (item1 < item2)
                    {
                        result[current] = item1;
                        current1++;
                    }
                    else
                    {
                        result[current] = item2;
                        current2++;
                    }

                    current++;
                }

                while (current1 < middle)
                {
                    result[current] = items[current1];
                    current1++;
                    current++;
                }

                while (current2 < end)
                {
                    result[current] = items[current2];
                    current2++;
                    current++;
                }

                for (var i = 0; i < current; i++)
                {
                    items[begin + i] = result[i];
                }
            }

            var cards = new int[] { 1, 3, 5, 2, 4, 6 };

            //merge(cards, 0, 3, cards.Length);

            //merge(cards, 0, 1, 2);
            //merge(cards, 2, 3, 4);
            //merge(cards, 0, 2, 4);
            //merge(cards, 4, 5, 6);
            //merge(cards, 0, 3, 6);

            sort(cards, 0, cards.Length);

            Array.ForEach(cards, Console.Write);
        }

        private static void StepThree()
        {
            var classroom4 = new Grade[]
            {
                new Grade("André", 4.0),
                new Grade("Lucia", 9.3),
                new Grade("Carlos", 8.5),
                new Grade("Jonas", 3.0),
                new Grade("Ana", 10.0),
                new Grade("Paulo", 9.0),
                new Grade("Mariana", 5.0),
                new Grade("Juliana", 6.7),
                new Grade("Gui", 7.0)
            };

            Console.WriteLine(new string('*', 100));

            Sort(classroom4, 0, classroom4.Length);

            foreach (var item in classroom4)
            {
                Console.WriteLine(item);
            }
        }

        private static void StepTwo()
        {
            var classroom3 = new Grade[]
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

            foreach (var item in Merge(classroom3, 0, 4, classroom3.Length))
            {
                Console.WriteLine(item);
            }
        }

        private static void StepOne()
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

            foreach (var item in Merge(classroom1, classroom2))
            {
                Console.WriteLine(item);
            }
        }

        public static void Sort(Grade[] classroom, int begin, int end)
        {
            var quantity = end - begin;

            if (quantity > 1)
            {
                var middle = (end + begin) / 2;
                Sort(classroom, begin, middle);
                Sort(classroom, middle, end);
                Merge(classroom, begin, middle, end);
            }
        }

        public static Grade[] Merge(Grade[] classroom, int begin, int middle, int end)
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

        public static Grade[] Merge(Grade[] grades1, Grade[] grades2)
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
