using System;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace WebCustomers.CommandLine
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var accountEndpoint = ConfigurationManager.AppSettings["accountEndpoint"];

            var accountKey = ConfigurationManager.AppSettings["accountKey"];

            var settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            var client = new DocumentClient(new Uri(accountEndpoint), accountKey, settings);

            await client.CreateDatabaseIfNotExistsAsync(new Database { Id = "Users" });

            await client.CreateDocumentCollectionIfNotExistsAsync(UriFactory.CreateDatabaseUri("Users"), new DocumentCollection { Id = "WebCustomers" });

            Console.WriteLine("Database and collection have been created.");

            var user = new User
            {
                Id = "1",
                UserId = "yanhe",
                LastName = "He",
                FirstName = "Yan",
                Email = "yanhe@contoso.com",
                OrderHistory = new OrderHistory[]
                {
                    new OrderHistory
                    {
                        OrderId = "1000",
                        DateShipped = "08/17/2018",
                        Total = "52.49"
                    }
                },
                ShippingPreference = new ShippingPreference[]
                {
                    new ShippingPreference
                    {
                            Priority = 1,
                            AddressLine1 = "90 W 8th St",
                            City = "New York",
                            State = "NY",
                            ZipCode = "10001",
                            Country = "USA"
                    }
                },
            };

            await CreateUserDocument(client, "Users", "WebCustomers", user);

            await ReadUserDocument(client, "Users", "WebCustomers", user);

            await ReplaceUserDocument(client, "Users", "WebCustomers", user);

            await DeleteUserDocument(client, "Users", "WebCustomers", user);

            await CreateUserDocument(client, "Users", "WebCustomers", user);

            ExecutingQuery(client, "Users", "WebCustomers");

            Console.WriteLine(user.UserId);

            await client.ExecuteStoredProcedureAsync<string>(UriFactory.CreateStoredProcedureUri("Users", "WebCustomers", "UpdateOrderTotal"), new RequestOptions { PartitionKey = new PartitionKey(user.UserId) });

            Console.WriteLine("Store procedure have been executed");
        }

        private static async Task CreateUserDocument(DocumentClient client, string database, string collection, User user)
        {
            try
            {
                await client.ReadDocumentAsync(UriFactory.CreateDocumentUri(database, collection, user.Id), new RequestOptions { PartitionKey = new PartitionKey(user.UserId) });
                Console.WriteLine("User already exists.");
            }
            catch (DocumentClientException ex)
            {
                if (ex.StatusCode == HttpStatusCode.NotFound)
                {
                    await client.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(database, collection), user);
                    Console.WriteLine("User have been created.");
                }
            }
        }

        private static async Task ReadUserDocument(DocumentClient client, string database, string collection, User user)
        {
            var response = await client.ReadDocumentAsync<User>(UriFactory.CreateDocumentUri(database, collection, user.Id), new RequestOptions { PartitionKey = new PartitionKey(user.UserId) });
            Console.WriteLine($"Reading informations about the user {response.Document.FirstName}.");
        }

        private static async Task ReplaceUserDocument(DocumentClient client, string database, string collection, User user)
        {
            user.FirstName = "Frank";
            await client.ReplaceDocumentAsync(UriFactory.CreateDocumentUri(database, collection, user.Id), user);
            Console.WriteLine($"Updating informations about the user {user.FirstName}");
        }

        private static async Task DeleteUserDocument(DocumentClient client, string database, string collection, User user)
        {
            await client.DeleteDocumentAsync(UriFactory.CreateDocumentUri(database, collection, user.Id), new RequestOptions { PartitionKey = new PartitionKey(user.UserId) });
            Console.WriteLine($"The user {user.FirstName} have been deleted.");
        }

        private static void ExecutingQuery(DocumentClient client, string database, string collection)
        {
            var feedOptions = new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = true };

            var linqQuery = client.CreateDocumentQuery<User>(UriFactory.CreateDocumentCollectionUri(database, collection), feedOptions).Where(it => it.Id == "1");

            Console.WriteLine(linqQuery);

            foreach (var it in linqQuery)
            {
                Console.WriteLine(it.FirstName);
            }

            var sqlQuery = client.CreateDocumentQuery<User>(UriFactory.CreateDocumentCollectionUri(database, collection), "SELECT * FROM WebCustomers WHERE WebCustomers.id = '1'", feedOptions);

            Console.WriteLine(sqlQuery);

            foreach (var it in sqlQuery)
            {
                Console.WriteLine(it.FirstName);
            }
        }
    }
}