using Microsoft.Owin.Hosting;
using System;

namespace OwinDemo.Pipeline
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using(WebApp.Start<Startup>("http://localhost:5000"))
            {
                Console.WriteLine("It's listening to http://localhost:5000");
                Console.WriteLine("Presse any key to finish it ...");
                Console.ReadLine();
            }
        }
    }
}