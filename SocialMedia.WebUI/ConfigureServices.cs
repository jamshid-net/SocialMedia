namespace SocialMedia.WebUI;

public static class ConfigureServices
{
    public static IServiceCollection AddWebUIService(this IServiceCollection services)
    {
        services.AddScoped<ICurrentUserService, CurrentUserService>();
        services.AddHttpContextAccessor();
        
        return services;
    }
}
