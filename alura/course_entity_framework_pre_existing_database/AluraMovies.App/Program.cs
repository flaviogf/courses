using System;
using AluraMovies.App.Data;

namespace AluraMovies.App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var context = new Context())
            {
                foreach (var actor in context.Actors)
                {
                    Console.WriteLine(actor);
                }
            }
        }
    }
}
