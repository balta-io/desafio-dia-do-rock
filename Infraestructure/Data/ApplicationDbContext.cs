using DesafioDiaDoRock.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace DesafioDiaDoRock.Infraestructure.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options ) : DbContext(options)
{
    public DbSet<Event> Event { get; set; }
}
