namespace ServiceTracker.Domain.Entities;

public class RefreshToken
{
    public Guid Id { get; private set; }
    public Guid UserId {get; private set; }
    
    public string TokenHash { get; private set; } = default!;

    public DateTime ExpiresAt { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? RevokedAt { get; private set; }

    public RefreshToken(
        Guid userId,
        string tokenHash,
        DateTime expiresAt
    )
    {
        if(userId == Guid.Empty)
            throw new ArgumentException("User ID cannot be empty.", nameof(userId));

        if(string.IsNullOrWhiteSpace(tokenHash))
            throw new ArgumentException(
                "Tokent hash cannot be null.",
                nameof(tokenHash)
            );

        if(expiresAt <= DateTime.UtcNow)
            throw new ArgumentException(
                "Refresh token expiration date must by in the future.",
                nameof(expiresAt)
            );

        Id = Guid.NewGuid();
        UserId = userId;
        TokenHash = tokenHash;
        ExpiresAt = expiresAt;
        CreatedAt = DateTime.UtcNow;
    }

    public void Revoked()
    {
        if (RevokedAt.HasValue)
            return;

        RevokedAt = DateTime.UtcNow;
    }
}