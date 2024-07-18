using DesafioDiaDoRock.ApplicationCore.Entities;
using DesafioDiaDoRock.ApplicationCore.Responses;

namespace DesafioDiaDoRock.ApplicationCore.Interfaces.Services
{
    public interface IEventService
    {
        Task<List<Event>?> Get(string search, CancellationToken cancellationToken = default);
        Task<List<Event>?> Get(CancellationToken cancellationToken = default);
        Task<Response<Event?>> Create(Event @event, CancellationToken cancellationToken = default);
    }
}