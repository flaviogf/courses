using System;
using System.Collections.Generic;

namespace Section7.IntroductionToEvents
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {

                Console.ForegroundColor = ConsoleColor.DarkYellow;

                var bell = new Bell();

                // bell.OnTouch += Touched;

                // bell.OnTouch += delegate ()
                // {
                //     Console.WriteLine("Touch (2)");
                // };

                // bell.OnTouch += () => Console.WriteLine("Touch (3)");

                // bell.OnTouch();

                bell.Touched += Touched;

                bell.Touched += delegate (object sender, BellTouchedEventArgs eventArgs)
                {
                    Console.WriteLine($"Touch (2) - Apartment: {eventArgs.Apartment}");

                    throw new Exception("Error 002");
                };

                bell.Touched += (sender, eventArgs) =>
                {
                    Console.WriteLine($"Touch (3) - Apartment: {eventArgs.Apartment}");

                    throw new Exception("Error 003");
                };

                // bell.Touched(null, new EventArgs());

                Console.WriteLine("bell will ring");

                bell.Touch("Apartment 1");

                bell.Touched -= Touched;

                Console.WriteLine("bell will ring");

                bell.Touch("Apartment 2");
            }
            catch (AggregateException ex)
            {
                Console.WriteLine(ex.Message);

                foreach (var item in ex.InnerExceptions)
                {
                    Console.WriteLine(item.InnerException.Message);
                }
            }
        }

        public static void Touched(object sender, BellTouchedEventArgs eventArgs)
        {
            Console.WriteLine($"Touch (1) - Apartment: {eventArgs.Apartment}");

            throw new Exception("Error 001");
        }
    }

    public class Bell
    {
        // public Action OnTouch { get; set; }

        public event EventHandler<BellTouchedEventArgs> Touched;

        public void Touch(string apartment)
        {
            var exceptions = new List<Exception>();

            foreach (var method in Touched?.GetInvocationList())
            {
                try
                {
                    method.DynamicInvoke(this, new BellTouchedEventArgs(apartment));
                }
                catch (Exception ex)
                {
                    exceptions.Add(ex);
                }
            }

            throw new AggregateException(exceptions);
        }
    }

    public class BellTouchedEventArgs : EventArgs
    {
        public BellTouchedEventArgs(string apartment)
        {
            Apartment = apartment;
        }

        public string Apartment { get; }
    }
}
