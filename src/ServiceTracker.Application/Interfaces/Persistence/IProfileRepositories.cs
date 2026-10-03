using ServiceTracker.Domain.Entities;

namespace ServiceTracker.Application.Interfaces.Persistence;

public interface IProfileRepositories
{
    Task<bool> ExistsByUsernameAsync(string username, CancellationToken cancellationToken);

    Task AddAsync(Profile profile, CancellationToken cancellationToken);
}