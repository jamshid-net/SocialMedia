namespace SocialMedia.WebUI;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        builder.Services.AddInfrastructureService(builder.Configuration);
        builder.Services.AddApplicationService();
        builder.Services.AddWebUIService();
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddLazyCache();
        
        var app = builder.Build();
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.DisplayRequestDuration();
            });
        }
        app.UseHttpsRedirection();
        app.UseGlobalExceptionMiddleware();
        app.UseAuthorization();

        app.UseResponseCaching();
        
        app.MapControllers();

        app.Run();
    }
}
