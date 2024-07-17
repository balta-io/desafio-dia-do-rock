﻿using DesafioDiaDoRock.ApplicationCore.Entities;
using DesafioDiaDoRock.ApplicationCore.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace DesafioDiaDoRock.PublicApi.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class EventController(IEventService eventService) : Controller
    {
        [HttpGet]
        public async Task<JsonResult> Get(string search, CancellationToken cancellationToken = default)
        {
            return new JsonResult(await eventService.Get(search,cancellationToken));
        }

        [HttpPost]
        public async Task<JsonResult> Create(Event @event, CancellationToken cancellationToken = default)
        {
            return new JsonResult(await eventService.Create(@event,cancellationToken));
        }
    }
}
