using DesafioDiaDoRock.ApplicationCore.Entities;
using DesafioDiaDoRock.ApplicationCore.Interfaces.Repositories;
using DesafioDiaDoRock.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DesafioDiaDoRock.Infraestructure.Repository
{
    public class EventRepository(ApplicationDbContext context) : IEventRepository
    {
        public async Task<Event?> Create(Event @event, CancellationToken cancellationToken)
        {
            context.Add(@event);
            await context.SaveChangesAsync(cancellationToken);

            return @event;
        }


        public async Task<List<Event>> Get(string search, CancellationToken cancellationToken)
        {
            var events = await context.Event.Where(e =>
                e.Band
                    .ToLower()
                    .Contains(search.ToLower())
                || e.NameLocation
                    .ToLower()
                    .Contains(search.ToLower())
                || e.Address
                    .ToLower()
                    .Contains(search.ToLower()))
                .ToListAsync(cancellationToken);

            return events;
        }


        public async Task<List<Event>> Get(CancellationToken cancellationToken)
            => await context.Event.ToListAsync(cancellationToken);        
    }
}
