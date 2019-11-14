using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Section6.CustomCollection
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;

            var carLicensePlates = new CarLicensePlates
            {
                "AAA-0000",
                "BBB-1111"
            };

            try
            {
                carLicensePlates.Add("test");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            carLicensePlates.Print();
        }
    }

    public class CarLicensePlates : ICollection<string>
    {
        private List<string> _list = new List<string>();

        public int Count => _list.Count;

        public bool IsReadOnly => false;

        public void Add(string item)
        {
            if (!IsValid(item))
            {
                throw new ArgumentException("License must be valid");
            }

            _list.Add(item);
        }

        public void Clear()
        {
            _list.Clear();
        }

        public bool Contains(string item)
        {
            return _list.Contains(item);
        }

        public void CopyTo(string[] array, int arrayIndex)
        {
            _list.CopyTo(array, arrayIndex);
        }

        public IEnumerator<string> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        public bool Remove(string item)
        {
            return _list.Remove(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        private bool IsValid(string license)
        {
            var regex = new Regex(@"^\w{3}-\d{4}$");

            return regex.IsMatch(license);
        }
    }

    public static class IEnumerableExtensions
    {
        public static void Print<T>(this IEnumerable<T> enumerable)
        {
            foreach (var item in enumerable)
            {
                Console.WriteLine(item);
            }
        }
    }
}
