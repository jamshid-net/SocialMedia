
namespace SocialMedia.Application.Common.JwtSettings;
public static class JwtTokenSettings
{
    public static AuthenticationBuilder AddJwtSetting(this AuthenticationBuilder builder, IConfiguration configuration)
    {
        builder.AddJwtBearer(cfg =>
        {
            cfg.SaveToken = true;
            cfg.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidateLifetime = true,
                ValidAudience = configuration.GetRequiredSection("JWT:Audience").Value,
                ValidIssuer = configuration.GetRequiredSection("JWT:Issuer").Value,
                ClockSkew = TimeSpan.Zero,
                IssuerSigningKey = new SymmetricSecurityKey
                                   (Encoding.UTF8.GetBytes(configuration.GetRequiredSection("JWT:Key").Value))

            };
            cfg.Events = new JwtBearerEvents()
            {
                OnAuthenticationFailed = context =>
                {
                    if(context.Exception.GetType() == typeof(SecurityException))
                    {
                        context.Response.Headers.Add("IS-TOKEN-EXPIRED", "true");
                    }
                    return Task.CompletedTask;
                }
            };

        });
        return builder;



    }
}
