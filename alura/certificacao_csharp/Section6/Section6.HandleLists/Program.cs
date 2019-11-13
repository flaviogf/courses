using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Section6.HandleLists
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;

            var episode4 = new Movie("Star Wars: Episode IV", 1977);
            var episode5 = new Movie("Star Wars: Episode V", 1980);
            var episode6 = new Movie("Star Wars: Episode VI", 1983);
            var episode1 = new Movie("Star Wars: Episode I", 1999);
            var episode2 = new Movie("Star Wars: Episode II", 2002);
            var episode3 = new Movie("Star Wars: Episode III", 2005);
            var episode7 = new Movie("Star Wars: Episode VII", 2015);
            var episode8 = new Movie("Star Wars: Episode VIII", 2017);

            var cloneWars = new Movie("Clone Wars", 2008);
            var rebels = new Movie("Rebels", 2014);

            var chronology = new List<Movie>();

            chronology.Add(episode4);
            chronology.Add(episode5);
            chronology.Add(episode6);

            chronology.Print();

            chronology = new List<Movie>();

            chronology.AddRange(new Movie[] { episode4, episode5, episode6 });

            chronology.Print();

            chronology = new List<Movie> { episode4, episode5, episode6 };

            chronology.Print();

            chronology.Insert(0, episode1);

            chronology.Print();

            chronology.InsertRange(1, new[] { episode2, episode3 });

            chronology.Print();

            Console.WriteLine($"IndexOf {nameof(episode4)} {chronology.IndexOf(episode4)}");

            Console.WriteLine();

            chronology.Insert(chronology.IndexOf(episode3), cloneWars);

            chronology.Insert(chronology.IndexOf(episode4), rebels);

            chronology.Print();

            var firstTrilogy = new List<Movie>(chronology);
            firstTrilogy.RemoveAll(it => it.Year > 1983);

            firstTrilogy.Print();

            var liveActions = new List<Movie>(chronology);
            liveActions.RemoveAt(liveActions.IndexOf(cloneWars));
            liveActions.RemoveAt(liveActions.IndexOf(rebels));

            liveActions.Print();

            chronology.Sort();

            chronology.Print();

            chronology.Sort((x, y) => x.Year.CompareTo(y.Year));

            chronology.Print();

            var secondTrilogy = new Movie[3];

            chronology.CopyTo(0, secondTrilogy, 0, 3);

            secondTrilogy.Print();

            var store = new Store();

            store.Editors.Print();

            // store.Editors[0].Name = "SOMETHING";

            // store.Editors.Print();

            // store.Editors = new List<Editor>();

            // store.Editors.Print();

            // store.Editors.Clear();

            // store.Editors.Print();
        }
    }

    public static class IEnumerableExtensions
    {
        public static void Print<T>(this IEnumerable<T> enumerable) where T : class
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine($"Count: {enumerable.Count()}");

            Console.ForegroundColor = ConsoleColor.Magenta;

            foreach (var item in enumerable)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
        }
    }

    public class Movie : IComparable<Movie>
    {
        public Movie(string name, int year)
        {
            Name = name;
            Year = year;
        }

        public string Name { get; set; }

        public int Year { get; set; }


        public override string ToString() => $"Movie[Name={Name}, Year={Year}]";

        public int CompareTo(Movie other)
        {
            if (other == null)
            {
                return 1;
            }

            return Name.CompareTo(other.Name);
        }
    }

    public class Editor
    {
        public Editor(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public override string ToString() => $"Editor=[Name={Name}]";
    }

    public class Store
    {
        private List<Editor> _editors;

        public Store()
        {
            _editors = new List<Editor>
            {
                new Editor("X"),
                new Editor("P"),
                new Editor("T"),
                new Editor("O")
            };
        }

        public IReadOnlyCollection<Editor> Editors => new ReadOnlyCollection<Editor>(_editors);
    }
}
