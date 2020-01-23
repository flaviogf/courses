using Microsoft.Owin.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace OwinDemo.Pipeline.Test
{
    [TestClass]
    public class OwinTests
    {
        [TestMethod]
        public async Task Should_Return_Status_200_When_Requesting_Root()
        {
            var response = await CallServer(async client =>
            {
                return await client.GetAsync("/");
            });

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public async Task Should_Return_Hello_World_When_Requesting_Root()
        {
            var body = await CallServer(async (client) =>
            {
                var response = await client.GetAsync("/");
                return await response.Content.ReadAsStringAsync();
            });

            Assert.AreEqual(body, "Hello, world.");
        }

        [TestMethod]
        public async Task Should_Return_The_Right_Content_Type_When_Requesting_A_File()
        {
            var contentType = await CallServer(async client =>
            {
                var response = await client.GetAsync("/avatar.png");
                return response.Content.Headers.ContentType.MediaType;
            });

            Assert.AreEqual("image/png", contentType);
        }

        private async Task<T> CallServer<T>(Func<HttpClient, Task<T>> callback)
        {
            using (var server = TestServer.Create<Startup>())
            {
                return await callback(server.HttpClient);
            }
        }
    }
}