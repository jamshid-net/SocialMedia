namespace SocialMedia.Application;
public static class ConfigureServices
{
    
    public static IServiceCollection AddApplicationService(this IServiceCollection services)
    {
        
        services.AddScoped<IHashStringService, HashStringService>();
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddMediatR(option =>
        {
            option.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
       

        });
        services.AddScoped<IUserRefreshTokenService, UserRefreshTokenService>();
        services.AddScoped<IJwtTokenService, JwtTokenService>();
        return services;
    }
}

