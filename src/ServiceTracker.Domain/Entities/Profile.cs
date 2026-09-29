
namespace ServiceTracker.Domain.Entities;

public class Profile
{
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public string Username { get; private set; } = default!;
    public string DisplayName { get; private set; } = default!;
    public string? AvatarUrl { get; private set; }
    public string? Bio { get; private set; }
    public DateTime? lastUserNameChangeAt { get; private set; }

    public Profile(
        Guid userId,
        string username,
        string displayName,
        string? avatarUrl,
        string? bio
    )
    {
        if(userId == Guid.Empty)
            throw new ArgumentException("User ID cannot be empty.", nameof(userId));

        if(string.IsNullOrWhiteSpace(username))
            throw new ArgumentException("Username cannot be empty.", nameof(username));

        if(string.IsNullOrWhiteSpace(displayName))
            throw new ArgumentException("Display name cannot be empty.", nameof(displayName));

        Id = Guid.NewGuid();
        UserId = userId;
        Username = username;
        DisplayName = displayName;
        AvatarUrl = avatarUrl;
        Bio = bio; 
    }
}