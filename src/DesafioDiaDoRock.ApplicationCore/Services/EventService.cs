using DesafioDiaDoRock.ApplicationCore.Entities;
using DesafioDiaDoRock.ApplicationCore.Interfaces.Repositories;
using DesafioDiaDoRock.ApplicationCore.Interfaces.Services;
using DesafioDiaDoRock.ApplicationCore.Responses;

namespace DesafioDiaDoRock.ApplicationCore.Services
{
    public class EventService(IEventRepository eventRepository) : IEventService
    {
        public async Task<List<Event>?> Get(string search, CancellationToken cancellationToken = default) 
            =>  await eventRepository.Get(search, cancellationToken);
        public async Task<Response<Event?>> Create(Event @event, CancellationToken cancellationToken = default)
            => new (await eventRepository.Create(@event, cancellationToken));
    }
}
