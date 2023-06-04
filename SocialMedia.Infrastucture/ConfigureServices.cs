
namespace SocialMedia.Infrastucture;
public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureService(this IServiceCollection services,IConfiguration configuration)
    {

        
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DbConnection"));
        });
        services.AddScoped<IApplicationDbContext>
            (provider=> provider.GetRequiredService<ApplicationDbContext>());
        return services;
    }
}
