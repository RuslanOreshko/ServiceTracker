namespace ServiceTracker.Domain.Entities;

public class User
{
    public Guid Id { get; private set; }

    public string Email { get; private set; } = default!;
    public string? PasswordHash { get; private set; }

    public string? GoogleId { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public User(
        string email,
        string? passwordHash = null,
        string? googleId = null

    )
    {
        if(string.IsNullOrWhiteSpace(email))
            throw new ArgumentException(
                "Email cannot be empty.",
                nameof(email)
            );

        if (string.IsNullOrWhiteSpace(passwordHash) &&
            string.IsNullOrWhiteSpace(googleId))
            throw new ArgumentException(
                "User must have at least one authentication method."
            );

        Id = Guid.NewGuid();
        Email = email;
        PasswordHash = passwordHash;
        GoogleId = googleId;
        CreatedAt = DateTime.UtcNow;
    }
}