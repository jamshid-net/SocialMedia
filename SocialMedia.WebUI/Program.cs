
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using SocialMedia.Application.Common.JwtSettings;
using SocialMedia.WebUI.GrpahqlServices;

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
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Example API", Version = "v1" });

            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Scheme = "bearer",
                Description = "Please insert JWT token into field"
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }
                }
            });

        });

        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtSetting(builder.Configuration);
        builder.Services.AddLazyCache();


        builder.Services.AddGraphqlServices();


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
        app.UseFileServer();
        app.UseStaticFiles();
        app.UseDefaultFiles();
        app.UseHttpsRedirection();
        app.UseGlobalExceptionMiddleware();
        app.UseAuthorization();

        app.UseGetRequestContentMiddleware();
        app.UseResponseCaching();
        app.UseEtagMidlleware();

        app.MapGraphQL();
        app.MapControllers();

        app.Run();
    }
}
