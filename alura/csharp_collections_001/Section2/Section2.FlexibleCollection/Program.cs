using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Section2.FlexibleCollection
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var lesson1 = new Lesson("Introduction to collections", 20);
            var lesson2 = new Lesson("Modeling the Lesson class", 18);
            var lesson3 = new Lesson("Working with sets", 16);

            var lessons = new List<Lesson>
            {
                lesson1,
                lesson2,
                lesson3
            };

            lessons.Print();

            lessons.Sort();

            lessons.Print();

            lessons.Sort((x, y) => x.Title.CompareTo(y.Title));

            lessons.Print();

            Console.WriteLine(lessons.Last());

            lessons.Reverse();

            lessons.Print();

            lessons.RemoveAt(lessons.Count - 1);

            lessons.Print();

            var clone = new List<Lesson>(lessons);

            clone.Print();

            clone.RemoveRange(1, 1);

            clone.Print();

            var course1 = new Course("C# Collections");

            course1.Add(lesson1);

            try
            {
                course1.Lessons.Add(lesson2);
            }
            catch (NotSupportedException ex)
            {
                Console.WriteLine(ex.Message);
            }

            course1.Add(lesson3);

            Console.WriteLine(course1);
        }
    }

    public class Course
    {
        private readonly IList<Lesson> _lessons;

        public Course(string name)
        {
            Name = name;
            _lessons = new List<Lesson>();
        }

        public string Name { get; }

        public IList<Lesson> Lessons
        {
            get
            {
                return new ReadOnlyCollection<Lesson>(_lessons);
            }
        }

        public void Add(Lesson lesson)
        {
            _lessons.Add(lesson);
        }

        public override string ToString()
        {
            return $"Course[Name=\"{Name}\", Lessons=[{string.Join(",", _lessons)}]]";
        }
    }

    public class Lesson : IComparable<Lesson>
    {
        public Lesson(string title, int minutes)
        {
            Title = title;
            Minutes = minutes;
        }

        public string Title { get; }

        public int Minutes { get; }

        public int CompareTo([AllowNull] Lesson other)
        {
            return Minutes.CompareTo(other?.Minutes);
        }

        public override string ToString()
        {
            return $"Lesson[Title=\"{Title}\", Minutes={Minutes}]";
        }
    }

    public static class EnumerableExtensions
    {
        public static void Print<T>(this IEnumerable<T> items)
        {
            Console.WriteLine(new string('_', 25));

            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }
    }
}
