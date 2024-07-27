using DesafioDiaDoRock.ApplicationCore.Entities;
using DesafioDiaDoRock.ApplicationCore.Responses;

namespace DesafioDiaDoRock.ApplicationCore.Interfaces.Services
{
    public interface IEventService
    {
        Task<List<Event>?> SearchInApprove(string search, CancellationToken cancellationToken = default);
        Task<List<Event>?> GetAllApprove(CancellationToken cancellationToken = default);
        Task<List<Event>?> GetAllToApprove(CancellationToken cancellationToken = default);
        Task<Response<Event?>> Create(Event @event, CancellationToken cancellationToken = default);
        Task<Response<Event?>> UpdateEvent(Event @event, CancellationToken cancellationToken = default);
    }
}