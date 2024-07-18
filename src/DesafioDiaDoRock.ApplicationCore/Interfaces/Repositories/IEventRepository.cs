using DesafioDiaDoRock.ApplicationCore.Entities;

namespace DesafioDiaDoRock.ApplicationCore.Interfaces.Repositories
{
    public interface IEventRepository
    {
        Task<Event?> Create(Event @event, CancellationToken cancellationToken);
        Task<List<Event>> Get(string search, CancellationToken cancellationToken = default);
        Task<List<Event>> Get(CancellationToken cancellationToken = default);
    }
}