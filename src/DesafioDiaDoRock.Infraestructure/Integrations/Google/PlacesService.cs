using DesafioDiaDoRock.ApplicationCore;
using DesafioDiaDoRock.ApplicationCore.Extension;
using DesafioDiaDoRock.ApplicationCore.Interfaces.Integrations;
using DesafioDiaDoRock.ApplicationCore.Models.Integrations;
using System.Text.Json;

namespace DesafioDiaDoRock.Infraestructure.Integrations.Google;

public class PlacesService() : IPlacesService
{
    public async Task<PlacesResult> GetPlaces(string textQuery)
    {
        HttpClient client = new();
        var request = new HttpRequestMessage(HttpMethod.Post, "https://places.googleapis.com/v1/places:searchText");

        request.Headers.Add("X-Goog-Api-Key", Configuration.GoogleApiKey);
        request.Headers.Add("X-Goog-FieldMask", "places.displayName,places.formattedAddress,places.location");

        var content = new { textQuery }.ToJson();

        request.Content = new StringContent(content);

        var result = await client.SendAsync(request);

        PlacesResult response = JsonSerializer.Deserialize<PlacesResult>(await result.Content.ReadAsStringAsync()) ?? new();

        return response;
    }
}
