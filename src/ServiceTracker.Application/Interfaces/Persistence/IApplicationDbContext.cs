namespace ServiceTracker.Application.Interfaces.Persistence;

public interface IApplicationDbContext
{
    Task<int> SaveChangesAsync(
        CancellationToken cancellationToken
    );
}