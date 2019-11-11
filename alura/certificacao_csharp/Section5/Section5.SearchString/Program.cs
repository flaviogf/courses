using static System.Console;
using System;
using System.IO;

namespace Section5.SearchString
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine(Contains("methods")(GetText()));
            WriteLine(Contains("anything")(GetText()));
            WriteLine(StartsWith("Provides")(GetText()));
            WriteLine(StartsWith("anything")(GetText()));
            WriteLine(EndsWith("objects")(GetText()));
            WriteLine(EndsWith("anything")(GetText()));
            WriteLine(IndexOf("objects")(GetText()));
            WriteLine(IndexOf("anything")(GetText()));
            WriteLine(Replace("Provides")("Xpto")(GetText()));
            WriteLine(Replace("anything")("Xpto")(GetText()));
        }

        static string GetText()
        {
            using (var stream = File.OpenText("file.txt"))
            {
                return stream.ReadToEnd();
            }
        }

        static Func<string, bool> Contains(string search) => (text) => text.Contains(search);

        static Func<string, bool> StartsWith(string search) => (text) => text.StartsWith(search);

        static Func<string, bool> EndsWith(string search) => (text) => text.EndsWith(search);

        static Func<string, int> IndexOf(string search) => (text) => text.IndexOf(search);

        static Func<string, Func<string, string>> Replace(string oldValue)
        {
            return (newValue) =>
            {
                return (text) =>
                {
                    return text.Replace(oldValue, newValue);
                };
            };
        }
    }
}
