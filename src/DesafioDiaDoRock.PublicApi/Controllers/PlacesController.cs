using DesafioDiaDoRock.ApplicationCore.Interfaces.Integrations;
using Microsoft.AspNetCore.Mvc;

namespace DesafioDiaDoRock.PublicApi.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class PlacesController(IPlacesService placesService) : Controller
    {
        [HttpGet]
        public async Task<JsonResult> GetPlaces(string textQuery)
        {
            return new JsonResult(await placesService.GetPlaces(textQuery));
        }
    }
}
