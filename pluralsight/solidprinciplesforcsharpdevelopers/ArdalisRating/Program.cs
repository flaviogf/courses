using System;

namespace ArdalisRating
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Ardalis Insurance Rating System Starting...");

            var engine = new RatingEngine();

            engine.Rate();

            if (engine.Rating > 0)
            {
                Console.WriteLine($"Rating: {engine.Rating}");

                return;
            }

            Console.WriteLine("No rating produced.");
        }
    }
}
