using Microsoft.EntityFrameworkCore;
using ServiceTracker.Application.Interfaces.Persistence;
using ServiceTracker.Domain.Entities;

namespace ServiceTracker.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepositories
{
    private readonly ServiceTrackerDbContext _dbContext;

    public UserRepository(
        ServiceTrackerDbContext dbContext
    )
    {
        _dbContext = dbContext;
    }

    public async Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _dbContext.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(
                x => x.Id == id,
                cancellationToken);
    }

    public async Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken)
    {
        return await _dbContext.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Email == email, cancellationToken);
    }

    public async Task<bool> ExistsByEmailAsync(string email, CancellationToken cancellationToken)
    {
        return await _dbContext.Users
            .AsNoTracking()
            .AnyAsync(x => x.Email == email, cancellationToken);
    }

    public async Task AddAsync(User user, CancellationToken cancellationToken)
    {
        await _dbContext.Users
            .AddAsync(user, cancellationToken);
    }
}