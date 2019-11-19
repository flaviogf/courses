using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Section8.AccessingTheWebAsynchronously
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            await Task.WhenAll(UsingWebClient(), UsingHttpClient());

            using (var stream = new FileStream("File.txt", FileMode.Create, FileAccess.Write))
            {
                var buffer = Encoding.UTF8.GetBytes("OK OK OK OK OK OK OK OK OK OK OK OK OK OK OK OK OK OK");

                await stream.WriteAsync(buffer, 0, buffer.Length);
            }

            using (var stream = new FileStream("File.txt", FileMode.Open, FileAccess.Read))
            {
                var buffer = new byte[128];

                var readed = -1;

                while ((readed = await stream.ReadAsync(buffer, 0, 128)) != 0)
                {
                    Console.WriteLine(Encoding.UTF8.GetString(buffer));
                }
            }
        }

        private static async Task UsingHttpClient()
        {
            Console.WriteLine("|> HttpClient | START <|");

            using (var client = new HttpClient())
            {
                var text = await client.GetStringAsync("https://pokeapi.co/api/v1/pokemon");

                var response = JsonConvert.DeserializeObject<Response<List<Pokemon>>>(text);

                response.Results.ForEach(Console.WriteLine);
            }

            Console.WriteLine("|> HttpClient | END <|");
        }

        private static async Task UsingWebClient()
        {
            Console.WriteLine("|> WebClient | START <|");

            using (var client = new WebClient())
            {
                var text = await client.DownloadStringTaskAsync("https://pokeapi.co/api/v2/pokemon");

                var response = JsonConvert.DeserializeObject<Response<List<Pokemon>>>(text);

                response.Results.ForEach(Console.WriteLine);
            }

            Console.WriteLine("|> WebClient | END <|");
        }
    }

    public class Response<T>
    {
        public T Results { get; set; }
    }

    public class Pokemon
    {
        public string Name { get; set; }

        public string Url { get; set; }

        public override string ToString() => $"Pokemon[Name={Name}, Url={Url}]";
    }
}
