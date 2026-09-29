using Microsoft.EntityFrameworkCore;
using ServiceTracker.Domain.Entities;

namespace ServiceTracker.Infrastructure.Persistence;

public class ServiceTrackerDbContext : DbContext
{
    public ServiceTrackerDbContext(DbContextOptions<ServiceTrackerDbContext> options) : base(options)
    {}

    public DbSet<User> Users => Set<User>();
    public DbSet<Profile> Profiles => Set<Profile>();
    public DbSet<Period> Periods => Set<Period>();
    public DbSet<Achivement> Achivements => Set<Achivement>();
    public DbSet<Event> GetEvents => Set<Event>();
    public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();
    public DbSet<PrivacySettings> PrivacySettings => Set<PrivacySettings>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(ServiceTrackerDbContext).Assembly
        );
    }
}