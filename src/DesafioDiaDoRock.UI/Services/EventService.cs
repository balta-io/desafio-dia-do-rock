using DesafioDiaDoRock.ApplicationCore.Entities;
using DesafioDiaDoRock.ApplicationCore.Interfaces.Services;
using DesafioDiaDoRock.ApplicationCore.Responses;
using System.Net.Http.Json;

namespace DesafioDiaDoRock.UI.Services
{
    public class EventService(IHttpClientFactory httpClientFactory) : IEventService
    {
        private readonly HttpClient _client = httpClientFactory.CreateClient(WebConfiguration.HttpClientName);

        public async Task<List<Event>?> Get(string search, CancellationToken cancellationToken = default)
        {
            return await _client.GetFromJsonAsync<List<Event>>($"/event?search={search}", cancellationToken);
        }

        public async Task<Response<Event?>> Create(Event @event, CancellationToken cancellationToken = default)
        {
            var result = await _client.PostAsJsonAsync<Event?>("/event", @event, cancellationToken);

            return await result.Content.ReadFromJsonAsync<Response<Event?>>(cancellationToken) ?? new Response<Event?>(null, 400, "Não foi possível criar o evento.");
        }
    }
}
