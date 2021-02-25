using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using GloboTicket.Services.ShoppingBasket.Entities;
using Microsoft.Extensions.Logging;

namespace GloboTicket.Services.ShoppingBasket.Services
{
    public class HttpEventCatalogService : IEventCatalogService
    {
        private readonly ILogger<HttpEventCatalogService> _logger;
        private readonly HttpClient _client;

        public HttpEventCatalogService(ILogger<HttpEventCatalogService> logger, HttpClient client)
        {
            _logger = logger;
            _client = client;
        }

        public async Task<Event> GetEvent(Guid eventId)
        {
            try
            {
                var response = await _client.GetAsync($"api/events/{eventId}");

                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();

                return JsonSerializer.Deserialize<Event>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, string.Empty);

                return null;
            }
        }
    }
}
