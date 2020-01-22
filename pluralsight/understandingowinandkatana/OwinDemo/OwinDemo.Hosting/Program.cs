using Microsoft.Owin.Hosting;
using System;

namespace OwinDemo.Hosting
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (WebApp.Start<Startup>("http://localhost:5000"))
            {
                Console.WriteLine("Listening http://localhost:5000");
                Console.ReadKey();
            }
        }
    }
}
