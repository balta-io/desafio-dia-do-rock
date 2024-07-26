using DesafioDiaDoRock.ApplicationCore.Entities;
using DesafioDiaDoRock.ApplicationCore.Interfaces.Services;
using DesafioDiaDoRock.ApplicationCore.Responses;
using System.Net.Http.Json;

namespace DesafioDiaDoRock.UI.Services
{
    public class EventService(IHttpClientFactory httpClientFactory) : IEventService
    {
        private readonly HttpClient _client = httpClientFactory.CreateClient(WebConfiguration.HttpClientName);

        public async Task<List<Event>?> SearchInApprove(string search, CancellationToken cancellationToken = default)
        {
            return await _client.GetFromJsonAsync<List<Event>>($"/event/{search}", cancellationToken);
        }

        public async Task<List<Event>?> GetAllApprove(CancellationToken cancellationToken = default)
        {
            return await _client.GetFromJsonAsync<List<Event>>($"/event", cancellationToken);
        }

        public async Task<List<Event>?> GetAllToApprove(CancellationToken cancellationToken = default)
        {
            return await _client.GetFromJsonAsync<List<Event>>($"/event/toapprove", cancellationToken);
        }

        public async Task<Response<Event?>> Create(Event @event, CancellationToken cancellationToken = default)
        {
            var result = await _client.PostAsJsonAsync<Event?>("/event", @event, cancellationToken);

            if (result.IsSuccessStatusCode)
                return await result.Content.ReadFromJsonAsync<Response<Event?>>(cancellationToken);
            else
                return new Response<Event?>(null, (int)result.StatusCode, "Não foi possível criar o evento.");
        }

        public async Task<Response<Event?>> UpdateEvent(Event @event, CancellationToken cancellationToken = default)
        {
            var result = await _client.PutAsJsonAsync<Event?>("/event", @event, cancellationToken);

            if (result.IsSuccessStatusCode)
                return await result.Content.ReadFromJsonAsync<Response<Event?>>(cancellationToken);
            else
                return new Response<Event?>(null, (int)result.StatusCode, "Não foi possível criar o evento.");
        }
    }
}
