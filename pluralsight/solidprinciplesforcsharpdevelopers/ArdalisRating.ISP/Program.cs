using System;

namespace ArdalisRating.ISP
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var engine = new RatingEngine();

            engine.Rate();

            if (engine.Rating > 0)
            {
                Console.WriteLine($"Rating: {engine.Rating}");

                return;
            }

            Console.WriteLine("No rating produced");
        }
    }
}
