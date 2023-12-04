using Microsoft.Extensions.Logging;
using Models;
using ServiceWorker.Services.Interfaces;
using System.Text.Json;

namespace ServiceWorker.Services
{
    public class CatalogService : ICatalogService
    {
        private HttpClient _httpClient;
        private JsonSerializerOptions _options;
        private ILogger<CatalogService> _logger;

        public CatalogService(HttpClient httpClient, ILogger<CatalogService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;

            _options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        public async Task<Concert> GetConcert(string concertid)
        {
            return JsonSerializer.Deserialize<Concert>(await _httpClient.GetStringAsync($"http://catalog.api:6002/api/v1/catalog/items/{concertid}"), _options);
        }
    }
}

