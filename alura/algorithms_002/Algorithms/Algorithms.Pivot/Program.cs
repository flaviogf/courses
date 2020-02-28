using System;

namespace Algorithms.Pivot
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var grades = new Grade[]
            {
                new Grade("André", 4),
                new Grade("Carlos", 8.5),
                new Grade("Ana", 10),
                new Grade("Jonas", 3),
                new Grade("Juliana", 6.7),
                new Grade("Lucia", 9.3),
                new Grade("Paulo", 9),
                new Grade("Mariana", 5),
                new Grade("Gui", 7),
            };

            Quicksort(grades, 0, grades.Length);

            foreach (var item in grades)
            {
                Console.WriteLine(item);
            }
        }

        private static void Quicksort(Grade[] grades, int begin, int end)
        {
            var quantity = end - begin;

            if (quantity > 1)
            {
                var pivot = Partition(grades, begin, end);
                Quicksort(grades, begin, pivot);
                Quicksort(grades, pivot + 1, end);
            }
        }

        private static int Partition(Grade[] grades, int begin, int end)
        {
            var pivot = grades[end - 1];

            var lowest = 0;

            for (var analysis = 0; analysis < end - 1; analysis++)
            {
                var grade = grades[analysis];

                if (grade.Value <= pivot.Value)
                {
                    Swipe(grades, analysis, lowest);
                    lowest++;
                }
            }

            Swipe(grades, end - 1, lowest);

            return lowest;
        }

        private static void Swipe(Grade[] grades, int from, int to)
        {
            var grade1 = grades[from];
            var grade2 = grades[to];
            grades[from] = grade2;
            grades[to] = grade1;
        }
    }
}
