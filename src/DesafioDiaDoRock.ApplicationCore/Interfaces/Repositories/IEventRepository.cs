using DesafioDiaDoRock.ApplicationCore.Entities;

namespace DesafioDiaDoRock.ApplicationCore.Interfaces.Repositories
{
    public interface IEventRepository
    {
        Task<Event?> Create(Event @event, CancellationToken cancellationToken);
        Task<List<Event>> Get(string search, CancellationToken cancellationToken = default);
        Task<List<Event>> GetApprove(CancellationToken cancellationToken = default);
        Task<List<Event>?> GetAllToApprove(CancellationToken cancellationToken);
        Task UpdateEvent(Event @event, CancellationToken cancellationToken = default);
    }
}