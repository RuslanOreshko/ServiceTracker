using ServiceTracker.Domain.Enums;

namespace ServiceTracker.Domain.Entities;

public class Achivement
{
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public AchivementType Type { get; private set; }
    public string Title { get; private set; } = default!;
    public string? Description { get; private set; }
    public DateOnly IssuedAt { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public Achivement(
        Guid userId,
        AchivementType type,
        string title,
        string? description,
        DateOnly issuedAt
    )
    {
        if(userId == Guid.Empty)
            throw new ArgumentException("User ID cannot be empty.", nameof(userId));

        if(!Enum.IsDefined(type))
            throw new ArgumentException(
                "Invalid achievement type",
                nameof(type)
            );

        if(string.IsNullOrWhiteSpace(title))
            throw new ArgumentException(
                "Title cannot be empty"
            );

        if(issuedAt > DateOnly.FromDateTime(DateTime.UtcNow))
            throw new ArgumentException(
                "Issued date canoot by in the future.",
                nameof(issuedAt)
            );

        
        UserId = userId;
        Type = type;
        Title = title;
        Description = description;
        IssuedAt = issuedAt;
        CreatedAt = DateTime.UtcNow;
    }
}