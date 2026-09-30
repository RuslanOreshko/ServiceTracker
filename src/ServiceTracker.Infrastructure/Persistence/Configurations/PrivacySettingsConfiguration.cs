using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceTracker.Domain.Entities;

namespace ServiceTracker.Infrastructure.Persistence.Configurations;

public class PrivacySettingsConfiguration : IEntityTypeConfiguration<PrivacySettings>
{
    public void Configure(EntityTypeBuilder<PrivacySettings> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.UserId)
            .IsRequired();

        builder.HasOne<User>()
            .WithOne();

        builder.HasIndex(x => x.UserId)
            .IsUnique();

        builder.Property(x => x.ShowDisplayName)
            .IsRequired();

        builder.Property(x => x.ShowAvatar)
            .IsRequired();

        builder.Property(x => x.ShowBio)
            .IsRequired();

        builder.Property(x => x.ShowPeriod)
            .IsRequired();

        builder.Property(x => x.ShowPeriodLocation)
            .IsRequired();

        builder.Property(x => x.ShowPeriodDescription)
            .IsRequired();

        builder.Property(x => x.ShowProgress)
            .IsRequired();

        builder.Property(x => x.ShowAchievement)
            .IsRequired();

        builder.Property(x => x.ShowEvent)
            .IsRequired();
    }
}