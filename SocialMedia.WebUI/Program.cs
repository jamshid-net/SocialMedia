
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Serilog;
using SocialMedia.Application.Common.JwtSettings;
using SocialMedia.WebUI.Middlewares;

namespace SocialMedia.WebUI;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        SerilogService.SerilogSettings(builder.Configuration);
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        builder.Host.UseSerilog();
        builder.Services.AddInfrastructureService(builder.Configuration);
        builder.Services.AddApplicationService();
        builder.Services.AddRateLimiterService();
        builder.Services.AddWebUIService();
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtSetting(builder.Configuration);
        builder.Services.AddLazyCache();
        
        var app = builder.Build();
        app.UseRateLimiter();

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
        
        app.UseGetRequestContentMiddleware();
        app.UseResponseCaching();
        app.UseEtagMidlleware();
        
        app.MapControllers();

        app.Run();
    }
}
