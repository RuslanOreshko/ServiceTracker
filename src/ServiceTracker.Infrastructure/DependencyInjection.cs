using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServiceTracker.Application.Interfaces.Persistence;
using ServiceTracker.Application.Interfaces.Services;
using ServiceTracker.Infrastructure.Authentication;
using ServiceTracker.Infrastructure.Persistence;
using ServiceTracker.Infrastructure.Persistence.Repositories;

namespace ServiceTracker.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        // Datebase connection
        services.AddDbContext<ServiceTrackerDbContext>(options =>
        {
            options.UseNpgsql(
                configuration.GetConnectionString("DefaultConnection")
            );
        });

        services.AddScoped<IApplicationDbContext>(provider => 
            provider.GetRequiredService<ServiceTrackerDbContext>());

        services.AddScoped<IUserRepositories, UserRepository>();
        services.AddScoped<IProfileRepositories, ProfileRepository>();
        services.AddScoped<IPrivacySettingsRepository, PrivacySettingsRepository>();

        services.AddScoped<IPasswordHasher, PasswordHasher>();

        return services;
    }
} 