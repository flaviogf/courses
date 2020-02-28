using System;

namespace Algorithms.Search
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var grades = new double[] { 4, 8.5, 10, 3, 6.7, 7, 9, 5, 9.3 };

            QuickSort(grades, 0, grades.Length);

            Console.WriteLine(new string('*', 100));

            Array.ForEach(grades, Console.WriteLine);

            Console.WriteLine(new string('*', 100));

            Console.WriteLine(LinearSearch(grades, 0, grades.Length, 7));

            Console.WriteLine(new string('*', 100));

            Console.WriteLine(BinarySearch(grades, 0, grades.Length, 7));
        }

        private static void QuickSort(double[] grades, int begin, int end)
        {
            var elements = end - begin;

            if (elements > 1)
            {
                var pivot = Partition(grades, begin, end);
                QuickSort(grades, begin, pivot);
                QuickSort(grades, pivot + 1, end);
            }
        }

        private static int Partition(double[] grades, int begin, int end)
        {
            var pivot = grades[end - 1];

            var lowests = 0;

            for (var i = 0; i < end - 1; i++)
            {
                if (grades[i] <= pivot)
                {
                    Swipe(grades, i, lowests);
                    lowests++;
                }
            }

            Swipe(grades, end - 1, lowests);

            return lowests;
        }

        private static void Swipe(double[] grades, int from, int to)
        {
            var grade1 = grades[from];
            var grade2 = grades[to];
            grades[to] = grade1;
            grades[from] = grade2;
        }

        private static int BinarySearch(double[] grades, int from, int to, double search)
        {
            if (from > to)
            {
                return -1;
            }

            var middle = (from + to) / 2;

            var grade = grades[middle];

            if (grade == search)
            {
                return middle;
            }

            if (search < grade)
            {
                return BinarySearch(grades, from, middle - 1, search);
            }

            return BinarySearch(grades, middle + 1, to, search);
        }

        private static int LinearSearch(double[] grades, int from, int to, double search)
        {
            for (var i = from; i < to; i++)
            {
                if (grades[i] == search)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
