using System;
using System.Collections.Generic;

namespace Section4.WorkingWithKeyAndValue
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var course1 = new Course("C# Collections");

            course1.Register(new Student("Frank", "123"));
            course1.Register(new Student("Fernando", "456"));
            course1.Register(new Student("Luis", "789"));
            course1.Register(new Student("Fatima", "987"));

            Console.WriteLine(course1);
        }
    }

    public class Course
    {
        private IDictionary<string, Student> _students = new Dictionary<string, Student>();

        public Course(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public void Register(Student student)
        {
            _students.Add(student.Registration, student);
        }

        public Student Get(string registration)
        {
            _students.TryGetValue(registration, out var student);

            return student;
        }

        public override string ToString()
        {
            return $"Course=[Name=\"{Name}\", Students=[{string.Join(",", _students.Values)}]]";
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
            return obj is Student student && Registration == student.Registration;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Registration);
        }

        public override string ToString()
        {
            return $"Student=[Name=\"{Name}\", Registration=\"{Registration}\"]";
        }
    }
}
