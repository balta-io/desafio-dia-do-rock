using DesafioDiaDoRock.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioDiaDoRock.Infraestructure.EntityTypeConfigurations;

public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
{
	public void Configure(EntityTypeBuilder<User> builder)
	{
		builder.ToTable("User");
		builder.HasKey(x => x.Id);
		builder.Property(x => x.Name).IsRequired();
		builder.Property(x => x.Email).IsRequired();
		builder.Property(x => x.Password).IsRequired();
		builder.Property(x => x.CreatedAt).IsRequired();
	}
}