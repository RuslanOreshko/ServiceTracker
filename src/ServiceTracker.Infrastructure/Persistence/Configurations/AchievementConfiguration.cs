using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceTracker.Domain.Entities;

namespace ServiceTracker.Infrastructure.Persistence.Configurations;

public class AchievementConfiguration : IEntityTypeConfiguration<Achivement>
{
    public void Configure(EntityTypeBuilder<Achivement> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.UserId)
            .IsRequired();

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(x => x.Type)
            .IsRequired();

        builder.Property(x => x.Title)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Description)
            .HasMaxLength(500);

        builder.Property(x => x.IssuedAt)
            .IsRequired();

        builder.Property(x => x.CreatedAt)
            .IsRequired();
    }
}