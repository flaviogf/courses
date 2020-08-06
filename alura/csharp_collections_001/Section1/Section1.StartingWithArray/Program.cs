using System;

namespace Section1.StartingWithArray
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var lesson1 = "Introduction to collection";
            var lesson2 = "Modeling the Lesson class";
            var lesson3 = "Working with sets";

            var lessons = new string[]
            {
                lesson1,
                lesson2,
                lesson3
            };

            Console.WriteLine(lessons[0]);
            Console.WriteLine(lessons[1]);
            Console.WriteLine(lessons[2]);

            try
            {
                Console.WriteLine(lessons[3]);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }

            lessons.Print();

            Console.WriteLine(lessons[lessons.Length - 1]);

            Console.WriteLine(lessons[^1]);

            Console.WriteLine(Array.IndexOf(lessons, lesson2));

            Array.Reverse(lessons);

            lessons.Print();

            Array.Resize(ref lessons, 2);

            lessons.Print();

            Array.Resize(ref lessons, 3);

            lessons.Print();

            Array.Sort(lessons);

            lessons.Print();

            var copy = new string[1];

            Array.Copy(lessons, 1, copy, 0, 1);

            copy.Print();

            var clone = lessons.Clone() as string[];

            clone.Print();

            Array.Clear(clone, 1, 1);

            clone.Print();
        }
    }

    public static class ArrayExtensions
    {
        public static void Print<T>(this T[] items)
        {
            Console.WriteLine(new string('_', 25));

            foreach (var item in items)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(new string('_', 25));
        }
    }
}
