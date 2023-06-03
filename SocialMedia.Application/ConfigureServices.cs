
namespace SocialMedia.Application;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationService(this IServiceCollection services)
    {
        services.AddScoped<IHashStringService, HashStringService>();
        services.AddAutoMapper(typeof(UserMapProfile));

        return services;
    }
}

