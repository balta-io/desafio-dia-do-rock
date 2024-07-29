using DesafioDiaDoRock.ApplicationCore.Entities;
using DesafioDiaDoRock.ApplicationCore.Interfaces.Repositories;
using DesafioDiaDoRock.ApplicationCore.Interfaces.Services;
using DesafioDiaDoRock.ApplicationCore.Responses;

namespace DesafioDiaDoRock.ApplicationCore.Services
{
    public class EventService(IEventRepository eventRepository, IEmailService emailService) : IEventService
    {
        public async Task<List<Event>?> SearchInApprove(string search, CancellationToken cancellationToken = default) 
            =>  await eventRepository.Get(search, cancellationToken);

        public async Task<List<Event>?> GetAllApprove(CancellationToken cancellationToken = default)
            => await eventRepository.GetApprove(cancellationToken);

        public async Task<List<Event>> GetAllToApprove(CancellationToken cancellationToken)
            => await eventRepository.GetAllToApprove(cancellationToken);

        public async Task<Response<Event?>> Create(Event @event, CancellationToken cancellationToken = default)
            => new (await eventRepository.Create(@event, cancellationToken));

        public async Task<Response<Event?>> UpdateEvent(Event @event, CancellationToken cancellationToken = default)
        {
            await eventRepository.UpdateEvent(@event, cancellationToken);

            if(@event.Approve == true)
            {
                await emailService.SendEmailForAlUser(@event);
            }
            return new();
        }
    }
}
