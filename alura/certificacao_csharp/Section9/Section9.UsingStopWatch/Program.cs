using System;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Section9.UsingStopWatch
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var watch = new Stopwatch();

            watch.Start();

            var connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\flavi\dev\courses\alura\certificacao_csharp\Section9\Section9.UsingStopWatch\database.mdf;Integrated Security=True;Connect Timeout=30";

            using var connection = new SqlConnection(connectionString);

            connection.Open();

            var cmdText = "INSERT INTO Movies (Name) VALUES(@name);";

            using var command = new SqlCommand(cmdText, connection);

            command.Parameters.AddWithValue("name", "Lord of the rings");

            command.ExecuteNonQuery();

            watch.Stop();

            Console.WriteLine($"Time: {watch.ElapsedMilliseconds}ms");
        }
    }
}
