using System.Security.Cryptography.X509Certificates;
using ServiceTracker.Application.DTOs.Auth;
using ServiceTracker.Application.Interfaces.Persistence;
using ServiceTracker.Application.Interfaces.Services;
using ServiceTracker.Domain.Entities;

namespace ServiceTracker.Application.Services;


public class AuthService : IAuthService
{
    private readonly IUserRepositories _userRepository;
    private readonly IProfileRepositories _profileRepository;
    private readonly IPrivacySettingsRepository _privacySettingsRepository;
    private readonly IPasswordHasher _passwordHasher;

    public AuthService(
        IUserRepositories userRepositories,
        IProfileRepositories profileRepositories,
        IPrivacySettingsRepository privacySettingsRepository,
        IPasswordHasher passwordHasher
    )
    {
        _userRepository = userRepositories;
        _profileRepository = profileRepositories;
        _privacySettingsRepository = privacySettingsRepository;

        _passwordHasher = passwordHasher;
    }

    public async Task<RegisterResponse> RegisterAsync(RegisterRequest request, CancellationToken cancellationToken)
    {
        var existsEmail = await _userRepository.ExistsByEmailAsync(request.Email, cancellationToken);

        var usernameExists = await _profileRepository.ExistsByUsernameAsync(request.Username, cancellationToken);

        if(existsEmail)
            throw new InvalidOperationException("User with this email alredy exists.");
        
        if(usernameExists)
            throw new InvalidOperationException("User with this Username alredy exists.");

        
        // Password hashing
        var passwordHash = _passwordHasher.Hash(request.Password);


        var user = new User(
            request.Email,
            passwordHash
        );

        await _userRepository.AddAsync(user, cancellationToken);


        var profile = new Profile(
            user.Id,
            request.Username,
            request.DisplayName
        );

        await _profileRepository.AddAsync(profile, cancellationToken);


        var privacySettings = new PrivacySettings(user.Id);

        await _privacySettingsRepository.Add(privacySettings, cancellationToken);

        // ОБОВЯЗКОВО ДОДАТИ SaveChange();

        return new RegisterResponse
        {
            UserId = user.Id,
            Email = user.Email,
            Username = profile.Username
        };
    }
}