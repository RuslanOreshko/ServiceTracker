using ServiceTracker.Domain.Enums;

namespace ServiceTracker.Domain.Entities;

public class Event
{
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public EventType Type { get; private set; }
    public string Title { get; private set; } = default!;
    public string? Description { get; private set; } 
    public DateOnly Date { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public Event(
        Guid userId,
        EventType type,
        string title,
        string? description,
        DateOnly date
    )
    {
        if(userId == Guid.Empty)
            throw new ArgumentException("User ID cannot be empty.", nameof(userId));

        if(!Enum.IsDefined(type))
            throw new ArgumentException(
                "Invalid event type.",
                nameof(type)
            );

        if(string.IsNullOrWhiteSpace(title))
            throw new ArgumentException(
                "Title cannot be empty."
            );

        if(date == default)
            throw new ArgumentException
            (
                "Date cannot be empty.",
                nameof(date)
            );

        Id = Guid.NewGuid();
        UserId = userId;
        Type = type;
        Title = title;
        Description = description;
        Date = date;
        CreatedAt = DateTime.UtcNow;
    }
}