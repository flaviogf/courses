using System;
using AluraMovies.App.Data;
using Microsoft.EntityFrameworkCore;

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

            using (var context = new Context())
            {
                foreach (var movie in context.Movies)
                {
                    Console.WriteLine(movie);
                }
            }

            using (var context = new Context())
            {
                foreach (var movie in context.Movies.Include(it => it.Actors).ThenInclude(it => it.Actor))
                {
                    Console.WriteLine("Movie: {0}", movie.Title);

                    foreach (var movieActor in movie.Actors)
                    {
                        Console.WriteLine("Actor: {0}", movieActor.Actor.FirstName);
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}
