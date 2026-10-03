namespace ServiceTracker.Application.DTOs.Auth;

public class RegisterResponse
{
    public Guid UserId { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Username { get; set; } = default!;
}