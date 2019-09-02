using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BookList.Cli
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using (var client = new HttpClient())
            {
                var user = new User
                {
                    Email = "flavio@email.com",
                    Password = "Test123!"
                };

                var json = JsonConvert.SerializeObject(user);

                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var authResponse = await client.PostAsync("http://localhost:5000/api/auth/signin", content);
                var token = await authResponse.Content.ReadAsStringAsync();

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var apiResponse = await client.GetAsync("http://localhost:6000/api/books?page=1");
                var result = await apiResponse.Content.ReadAsStringAsync();
                var books = JsonConvert.DeserializeObject<List<Book>>(result);

                books.ForEach(Console.WriteLine);
            }
        }
    }
}
