using ServiceTracker.Domain.Entities;

namespace ServiceTracker.Application.Interfaces.Persistence;


public interface IPrivacySettingsRepository
{
    Task Add(PrivacySettings privacySettings, CancellationToken cancellationToken);
}