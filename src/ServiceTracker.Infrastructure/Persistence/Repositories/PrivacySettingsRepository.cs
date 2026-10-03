using ServiceTracker.Application.Interfaces.Persistence;
using ServiceTracker.Domain.Entities;

namespace ServiceTracker.Infrastructure.Persistence.Repositories;


public class PrivacySettingsRepository : IPrivacySettingsRepository
{
    private readonly ServiceTrackerDbContext _dbContext;

    public PrivacySettingsRepository(
        ServiceTrackerDbContext dbContext
    )
    {
        _dbContext = dbContext;
    }

    public async Task Add(PrivacySettings privacySettings, CancellationToken cancellationToken)
    {
        await _dbContext.PrivacySettings
            .AddAsync(privacySettings, cancellationToken);
    }
}