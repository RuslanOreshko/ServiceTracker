using ServiceTracker.Domain.Entities;

namespace ServiceTracker.Application.Interfaces.Persistence;


public interface IPrivacySettingsRepository
{
    Task AddAsync(PrivacySettings privacySettings, CancellationToken cancellationToken);
}