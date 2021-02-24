using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using GloboTicket.Client.Models.Api;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace GloboTicket.Client.Services
{
    public class HttpEventCatalogService : IEventCatalogService
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;

        public HttpEventCatalogService(IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            using var client = _httpClientFactory.CreateClient();

            client.BaseAddress = new Uri(_configuration["Services:EventCatalogService:Uri"]);

            var response = await client.GetAsync("/api/categories");

            return JsonConvert.DeserializeObject<IEnumerable<Category>>(await response.Content.ReadAsStringAsync());
        }

        public async Task<IEnumerable<Event>> GetAllEvents(Guid? categoryId = null)
        {
            using var client = _httpClientFactory.CreateClient();

            client.BaseAddress = new Uri(_configuration["Services:EventCatalogService:Uri"]);

            var response = await client.GetAsync($"/api/events?categoryId={categoryId}");

            return JsonConvert.DeserializeObject<IEnumerable<Event>>(await response.Content.ReadAsStringAsync());
        }

        public async Task<Event> GetEvent(Guid id)
        {
            using var client = _httpClientFactory.CreateClient();

            client.BaseAddress = new Uri(_configuration["Services:EventCatalogService:Uri"]);

            var response = await client.GetAsync($"/api/events/{id}");

            return JsonConvert.DeserializeObject<Event>(await response.Content.ReadAsStringAsync());
        }
    }
}
