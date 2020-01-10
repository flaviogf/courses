using Serilog;
using System;
using System.Net;
using System.Text;
using System.Threading;

namespace ByteBank.Portal
{
    public class Program
    {
        public static void Main(string[] args) => RunApp(() =>
        {
            var listener = new HttpListener();

            var logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();

            using var server = new Server(listener, logger);

            server.Static("/static");

            server.Get("/", (req, res) =>
            {
                var buffer = Encoding.UTF8.GetBytes("ByteBank");

                res.StatusCode = 200;

                res.ContentType = "text/html; charset=utf-8";

                res.ContentLength64 = buffer.Length;

                res.OutputStream.Write(buffer, 0, buffer.Length);
            });

            server.Listen("http://localhost:5341/");
        });

        public static void RunApp(Action action)
        {
            while (true)
            {
                action();

                Thread.Sleep(500);
            }
        }
    }
}
