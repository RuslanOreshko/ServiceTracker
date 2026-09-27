using ServiceTracker.Domain.Enums;

namespace ServiceTracker.Domain.Entities;

public class Period
{
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public PeriodType Type { get; private set; }
    public string Title { get; private set; } = default!;
    public DateOnly StartDate { get; private set; }
    public DateOnly? EndDate { get; private set; }
    public string? Description { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public Period(
        Guid userId,
        PeriodType type,
        string title,
        DateOnly startDate,
        DateOnly? endDate,
        string? description
    )
    {
        if(userId == Guid.Empty)
            throw new ArgumentException("User ID cannot by empty.", nameof(userId));

        if (!Enum.IsDefined(type))
        {
            throw new ArgumentException(
                "Invalid period type.",
                nameof(type)
            );
        }

        if(string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title cannot be empty.", nameof(title));

        if(startDate == default)
            throw new ArgumentException(
                "Start Date cannot by empty.",
                nameof(startDate)
            );

        if(endDate.HasValue && startDate >= endDate.Value)
        {
            throw new ArgumentException("Start date must be early than end date.");
        }

        
        UserId = userId;
        Type = type;
        Title = title;
        StartDate = startDate;
        EndDate = endDate;
        Description = description;
        CreatedAt = DateTime.UtcNow;
    }
}