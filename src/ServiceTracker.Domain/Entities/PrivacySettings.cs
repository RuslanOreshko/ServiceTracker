namespace ServiceTracker.Domain.Entities;

public class PrivacySettings
{
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }

    public bool ShowDisplayName { get; private set; }
    public bool ShowAvatar { get; private set; }
    public bool ShowBio { get; private set; }

    public bool ShowPeriod { get; private set; }
    public bool ShowPeriodLocation { get; private set; }
    public bool ShowPeriodDescription { get; private set; }
    public bool ShowProgress { get; private set; }

    public bool ShowAchievement { get; private set; }
    public bool ShowEvent { get; private set; }

    public PrivacySettings(Guid userId)
    {
        if(userId == Guid.Empty)
            throw new ArgumentException("User ID cannot be empty.", nameof(userId));

        ShowDisplayName = true;
        ShowAvatar = true;
        ShowBio = true;

        ShowPeriod = true;
        ShowPeriodLocation = false;
        ShowPeriodDescription = true;
        ShowProgress = true;

        ShowAchievement = true;
        ShowEvent = true;
 
    }
}