using DesafioDiaDoRock.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DesafioDiaDoRock.Infraestructure.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options ) : DbContext(options)
{
    public DbSet<Event> Event { get; set; }
    public DbSet<User> User { get; set; }
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		base.OnModelCreating(modelBuilder);
	}
}
