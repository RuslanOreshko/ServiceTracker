using Microsoft.EntityFrameworkCore;
using ServiceTracker.Application.Interfaces.Persistence;
using ServiceTracker.Domain.Entities;

namespace ServiceTracker.Infrastructure.Persistence.Repositories;

public class ProfileRepository : IProfileRepositories
{
    private readonly ServiceTrackerDbContext _dbContext;

    public ProfileRepository(
        ServiceTrackerDbContext dbContext
    )
    {
        _dbContext = dbContext;
    }

    public async Task<bool> ExistsByUsernameAsync(string username, CancellationToken cancellationToken)
    {
        return await _dbContext.Profiles
            .AsNoTracking()
            .AnyAsync(x => x.Username == username, cancellationToken);
    }

    public async Task AddAsync(Profile profile, CancellationToken cancellationToken)
    {
        await _dbContext.Profiles
            .AddAsync(profile, cancellationToken);
    }
}