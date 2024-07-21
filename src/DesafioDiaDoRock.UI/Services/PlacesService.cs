using DesafioDiaDoRock.ApplicationCore.Interfaces.Integrations;
using DesafioDiaDoRock.ApplicationCore.Models.Integrations;
using System.Net.Http.Json;

namespace DesafioDiaDoRock.UI.Services
{
    public class PlacesService(IHttpClientFactory httpClientFactory) : IPlacesService
    {
        private readonly HttpClient _client = httpClientFactory.CreateClient(WebConfiguration.HttpClientName);

        public async Task<PlacesResult> GetPlaces(string textQuery)
        {
            return await _client.GetFromJsonAsync<PlacesResult>($"/places?textQuery={textQuery}") ?? new();
        }
    }
}
