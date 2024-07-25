using DesafioDiaDoRock.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioDiaDoRock.Infraestructure.EntityTypeConfigurations;

public class EventEntityTypeConfiguration : IEntityTypeConfiguration<Event>
{
	public void Configure(EntityTypeBuilder<Event> builder)
	{
		builder.ToTable("Event");
		builder.HasKey(x => x.Id);
		builder.Property(x => x.Band).IsRequired();
		builder.Property(x => x.Date).IsRequired();
		builder.Property(x => x.NameLocation).IsRequired();
		builder.Property(x => x.Address).IsRequired();
		builder.Property(x => x.Latitude).HasColumnType("decimal(18,6)").IsRequired();
		builder.Property(x => x.Longitude).HasColumnType("decimal(18,6)").IsRequired();
		builder.Property(x => x.UrlImage).IsRequired();
	}
}