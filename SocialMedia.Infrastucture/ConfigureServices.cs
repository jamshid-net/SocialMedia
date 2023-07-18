
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;

namespace SocialMedia.Infrastucture;
public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureService(this IServiceCollection services,IConfiguration configuration)
    {

        services.AddDbContext<ApplicationDbContext>(options =>
         {
             options.UseLazyLoadingProxies();
             options.UseNpgsql(configuration.GetConnectionString("DbConnection"));
     
         })
         .AddDataProtection()
         .SetApplicationName("SocialMedia.WebUI")
         .UseCryptographicAlgorithms(
           new AuthenticatedEncryptorConfiguration()
           {
               EncryptionAlgorithm = EncryptionAlgorithm.AES_256_CBC,
               ValidationAlgorithm = ValidationAlgorithm.HMACSHA256
           })
         .AddKeyManagementOptions(options =>
         {
             options.NewKeyLifetime = new TimeSpan(30, 0, 0, 0);
             options.AutoGenerateKeys = true;
         })
         .PersistKeysToDbContext<ApplicationDbContext>();
        services.AddScoped<IApplicationDbContext>
            (provider=> provider.GetRequiredService<ApplicationDbContext>());
        return services;
    }
}
