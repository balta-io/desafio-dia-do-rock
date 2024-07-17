using DesafioDiaDoRock.ApplicationCore.Models.Integrations;

namespace DesafioDiaDoRock.ApplicationCore.Interfaces.Integrations
{
    public interface IPlacesService
    {
        Task<PlacesResult> GetPlaces(string textQuery);
    }
}