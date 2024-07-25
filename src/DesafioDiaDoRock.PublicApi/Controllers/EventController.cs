using DesafioDiaDoRock.ApplicationCore.Entities;
using DesafioDiaDoRock.ApplicationCore.Interfaces.Services;
using DesafioDiaDoRock.ApplicationCore.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace DesafioDiaDoRock.PublicApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;
        private readonly TokenService _tokenService;

        public EventController(IEventService eventService, TokenService tokenService)
        {
            _eventService = eventService;
            _tokenService = tokenService;
        }

        [HttpGet("{search}")]
        //[Authorize(Policy = "RequireJwt")]
        public async Task<IActionResult> Get(string search, CancellationToken cancellationToken = default)
        {
            var result = await _eventService.Get(search, cancellationToken);
            if (result == null)
            {
                return NotFound("No events found.");
            }
            return Ok(result);
        }

        [HttpGet]
        //[Authorize(Policy = "RequireJwt")]
        public async Task<IActionResult> Get(CancellationToken cancellationToken = default)
        {
            var result = await _eventService.Get(cancellationToken);
            if (result == null)
            {
                return NotFound("No events found.");
            }
            return Ok(result);
        }

        [HttpPost]
         //[AllowAnonymous] Permitir acesso sem autenticação para criar o evento e obter o token
        public async Task<IActionResult> Create([FromBody] Event @event, CancellationToken cancellationToken = default)
        {
            if (@event == null)
            {
                return BadRequest("Event data is required.");
            }

            var result = await _eventService.Create(@event, cancellationToken);
            if (result == null)
            {
                return StatusCode(500, "An error occurred while creating the event.");
            }

            return Ok(new { Event = result });
        }
    }
}
