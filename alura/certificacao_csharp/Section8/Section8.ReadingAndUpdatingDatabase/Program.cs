using System;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Section8.ReadingAndUpdatingDatabase
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            await Read();

            await Update();

            await Read();

            await Undo();

            await Read();

            await UpdateWithParameters();

            await Read();
        }

        public async static Task Read()
        {
            var connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\flavi\dev\courses\alura\certificacao_csharp\Section8\Section8.ReadingAndUpdatingDatabase\database.mdf;Integrated Security=True;Connect Timeout=30";

            var cmdText = @"SELECT d.Id as DirectorId, d.Name as DirectorName, m.Id as MovieId, m.Name as MovieName FROM Directors d
                          INNER JOIN Movies m
                          ON d.Id = m.DirectorId;";

            using var connection = new SqlConnection(connectionString);

            using var command = new SqlCommand(cmdText, connection);

            await connection.OpenAsync();

            using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                var directorId = reader.GetInt32(reader.GetOrdinal("DirectorId"));
                var directorName = reader.GetString(reader.GetOrdinal("DirectorName"));
                var movieId = reader.GetInt32(reader.GetOrdinal("MovieId"));
                var movieName = reader.GetString(reader.GetOrdinal("MovieName"));
                Console.WriteLine($"Director[Id={directorId}, Name={directorName}] - Movie[Id={movieId}, Name={movieName}]");
            }
        }

        public async static Task Update()
        {
            var connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\flavi\dev\courses\alura\certificacao_csharp\Section8\Section8.ReadingAndUpdatingDatabase\database.mdf;Integrated Security=True;Connect Timeout=30";

            var cmdText = @"UPDATE Directors SET NAME = 'Michael' WHERE ID = 1";

            using var connection = new SqlConnection(connectionString);

            using var command = new SqlCommand(cmdText, connection);

            await connection.OpenAsync();

            var lines = await command.ExecuteNonQueryAsync();

            Console.WriteLine("Updated lines {0}", lines);
        }

        public async static Task Undo()
        {
            var connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\flavi\dev\courses\alura\certificacao_csharp\Section8\Section8.ReadingAndUpdatingDatabase\database.mdf;Integrated Security=True;Connect Timeout=30";

            var cmdText = @"UPDATE Directors SET NAME = 'Michael Bay' WHERE ID = 1";

            using var connection = new SqlConnection(connectionString);

            using var command = new SqlCommand(cmdText, connection);

            await connection.OpenAsync();

            var lines = await command.ExecuteNonQueryAsync();

            Console.WriteLine("Updated lines {0}", lines);
        }

        public async static Task UpdateWithParameters()
        {
            Console.Write("Enter movie id to be modified: ");
            var movieId = Console.ReadLine();
            Console.Write("Enter new movie name: ");
            var movieName = Console.ReadLine();

            var connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\flavi\dev\courses\alura\certificacao_csharp\Section8\Section8.ReadingAndUpdatingDatabase\database.mdf;Integrated Security=True;Connect Timeout=30";

            using var connection = new SqlConnection(connectionString);

            var cmdText = "UPDATE Movies SET Name = @movieName WHERE Id = @movieId";

            using var command = new SqlCommand(cmdText, connection);
            command.Parameters.AddWithValue("@movieName", movieName);
            command.Parameters.AddWithValue("@movieId", movieId);

            await connection.OpenAsync();

            var lines = await command.ExecuteNonQueryAsync();

            Console.WriteLine("Updated lines {0}", lines);
        }
    }
}
