using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Section3.ThePowerOfSets
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var students = new HashSet<string>();

            students.Add("Vanessa");
            students.Add("Ana");
            students.Add("Rafael");

            students.Print();

            students.Remove("Ana");

            students.Print();

            var course = new Course("C# Collections");

            course.Register(new Student("Vanessa", "123"));
            course.Register(new Student("Ana", "456"));
            course.Register(new Student("Rafael", "789"));

            course.Students.Print();

            course.Register(new Student("Pedro", "111"));
            course.Register(new Student("Ana", "456"));

            course.Students.Print();
        }
    }

    public static class EnumerableExtensions
    {
        public static void Print<T>(this IEnumerable<T> items)
        {
            Console.WriteLine(new string('*', 25));

            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }
    }

    public class Course
    {
        private readonly ISet<Student> _students = new HashSet<Student>();

        public Course(string title)
        {
            Title = title;
        }

        public string Title { get; }

        public IReadOnlyList<Student> Students
        {
            get
            {
                return new ReadOnlyCollection<Student>(_students.ToList());
            }
        }

        public void Register(Student student)
        {
            _students.Add(student);
        }
    }

    public class Student
    {
        public Student(string name, string registration)
        {
            Name = name;
            Registration = registration;
        }

        public string Name { get; }

        public string Registration { get; }

        public override bool Equals(object obj)
        {
            return obj is Student student && Name == student.Name && Registration == student.Registration;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Registration);
        }

        public override string ToString()
        {
            return $"Student[Name=\"{Name}\", Registration=\"{Registration}\"]";
        }
    }
}
